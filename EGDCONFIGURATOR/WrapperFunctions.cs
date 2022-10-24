using GeCss.Automation;
using GeCss.Config.SystemConfig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace EGDCONFIGURATOR
{
    public class WrapperFunctions
    {
        string TcwPath = string.Empty;
        ISystem TcwSystem = SystemFactory.CreateNewSystem();

        public WrapperFunctions(string Path)
        {
            TcwPath = Path;
            TcwSystem.Name = TcwPath.ToString().Split('\\').Last().TrimEnd('\\').Split('.').First();
            TcwSystem.WorkingDirectory = TcwPath.ToString().Replace(TcwPath.ToString().Split('\\').Last().TrimEnd('\\'), "");
        }
        public enum Devices
        {
            /// <summary>
            /// Enumerations for the device type selection.
            /// </summary>
            All,
            MarkVIe,
            MarkVIeS,
            WorkStation,
            External
        }
        public enum FetchVariable
        {
            /// <summary>
            /// Enumerations for the variable type selection.
            /// </summary>
            All,
            ProgramLevel,
            TaskLevel

        }
        public enum VariableScope
        {
            /// <summary>
            /// Enumerations for the variable Scope selection.
            /// </summary>
            All = 1,
            Global = 0,
            Local = 2
        }
        public enum Mode
        {
            /// <summary>
            /// Enumerations for the device type selection.
            /// </summary>
            XML,
            API
        }
        public string GetTcwVersion([Optional] Mode Mode, ref string Error)
        {
            /// <summary>
            /// Gets the version of selected TCW file.
            /// </summary>
            /// <param name="FileName">Name of selected TCW file.</param>
            /// <param name="Mode">Mode to get the version(Possible values are XML,API).</param>
            /// <returns>Function returns the selected TCW version.</returns>
            string strVersion = string.Empty;
            try
            {
                if (Mode.ToString() == "API")
                {
                    TcwSystem.Open();
                    strVersion = TcwSystem.ReadinVersion.ToString();
                }
                else
                {
                    strVersion = string.Join(",", (XDocument.Parse(File.ReadAllText(TcwPath).ToString()).Descendants("SystemConfig").First().Attribute("WrittenByToolVersion").Value.ToString()));//XML version of fetching Version

                }
                return strVersion;
            }
            catch (Exception ex)
            {
                Logging("GetTcwVersion", ex, "");
                Error = ex.Message.ToString();
                return strVersion;
            }
        }
        public string[] GetDevicesList(Devices DeviceType, [Optional] Mode Mode, ref string Error)//Need to give optional param for mode, DeviceType #defdault will be XML.#defdault will be All for devicetype.
        {
            /// <summary>
            /// Gets the device list of selected TCW file.
            /// </summary>
            /// <param name="TcwPath">TcwPath of selected TCW file.</param>
            /// <param name="DeviceType">Device type to get.</param>
            /// <param name="version">Mode to get the version(Possible values are XML,API).</param>
            /// <returns>Function returns the device list of selected TCW file.</returns>
            string[] response = new string[] { };
            string DeviceName = DeviceType.ToString().ToUpper() == "MARKVIE" ? "MarkVIe" : DeviceType.ToString().ToUpper() == "MARKVIES" ? "MarkVIeS" :
                                            DeviceType.ToString().ToUpper() == "WORKSTATION" ? "Workstation" : DeviceType.ToString().ToUpper() == "EXTERNAL" ? "External" : "ALL";
            try
            {
                if (Mode.ToString().ToUpper() == "XML")
                {
                    string TcwXmlFile = File.ReadAllText(TcwPath);
                    response = XDocument.Parse(TcwXmlFile).Descendants("SystemConfig").Elements("System").Elements("DeviceInfo").Where(xx => xx.Attribute("type").Value.ToString().Equals(DeviceName)).Select(xx => xx.Attribute("name").Value).ToArray();
                }
                else
                {
                    List<string> lstTemp = new List<string>();
                    //TcwSystem.Name = TcwPath.ToString().Split('\\').Last().TrimEnd('\\').Split('.').First();
                    //TcwSystem.WorkingDirectory = TcwPath.ToString().Replace(TcwPath.ToString().Split('\\').Last().TrimEnd('\\'), "");
                    TcwSystem.Open();
                    IDevice d1;
                    IMarkVIeDevice g1;
                    string[] Names = TcwSystem.Devices.Names;
                    string[] NullProgNames = new string[] { };
                    var field = TcwSystem.Devices.GetType().GetField("b", BindingFlags.NonPublic | BindingFlags.Instance);
                    var DeviceInfoList = field.GetValue(TcwSystem.Devices);
                    IEnumerable enumerable = DeviceInfoList as IEnumerable;
                    var arr = ((IEnumerable)DeviceInfoList).Cast<DeviceInfo>()
                             .Select(x => x)
                             .ToArray();

                    foreach (DeviceInfo deviceInfo in arr)
                    {
                        if (DeviceName.ToString().ToUpper() == "ALL" || (deviceInfo.DeviceType.ToString().ToUpper() == DeviceName.ToUpper()))
                        {
                            lstTemp.Add(deviceInfo.Name);
                        }
                    }

                    response = lstTemp.ToArray();
                }

                return response;
            }
            catch (Exception ex)
            {
                Logging("GetDevicesList", ex, "");
                Error = ex.Message.ToString();
                return response;
            }
        }
        public DataTable GetVariablesWithProperties(string DeviceName, [Optional] VariableScope variableScope, ref Hashtable hshDevices, ref string Error)//Just one device to perform GVL extraction, Need to add the var scope as parameter
        {
            /// <summary>
            /// Gets the variable list with all the properties of selected device(s).
            /// </summary>
            /// <param name="TcwPath">TcwPath of selected TCW file.</param>
            /// <param name="DeviceToExtract">Device type to get.</param>
            /// <param name="variableScope">Variable scope defines to extract all or only global or only local</param>
            /// <returns>Function returns the device list of selected TCW file.</returns>
            DataTable dtRes = new DataTable();
            string Message = string.Empty;
            string MarkVIe = string.Empty;
            string MarkVIeS = string.Empty;
            try
            {
                IDevice d1 = null;
                //if (device == null)
                if (!hshDevices.ContainsKey(DeviceName))
                {
                    TcwSystem.Open();
                    d1 = TcwSystem.OpenDevice(DeviceName, null);
                    hshDevices.Add(DeviceName, d1);
                }
                else
                    d1 = (IDevice)hshDevices[DeviceName];

                dtRes = GetVariablesList(d1, variableScope, ref Error);


                return dtRes;
            }
            catch (Exception ex)
            {
                Logging("GetVariablesWithProperties", ex, "");
                Error = ex.Message.ToString();
                return dtRes;
            }
        }
        private DataTable GetVariablesList(IDevice Device, VariableScope variableScope, ref string Error)
        {
            /// <summary>
            /// Gets the variable list with all the properties of selected device(s).
            /// </summary>
            DataTable dtRes = new DataTable();
            IMarkVIeDevice MVIE1;
            IMarkVIeSDevice MVIES1;
            try
            {
                if (Device.DeviceType.ToString().ToUpper() == "MARKVIE")
                {
                    MVIE1 = (IMarkVIeDevice)Device;
                    IProgramList programList = MVIE1.Programs;
                    IProgram prog;
                    List<IUserBlockList> Tsklst = new List<IUserBlockList>();
                    List<string> TotalVar = new List<string>();
                    foreach (IProgram TmpProg in programList)
                    {
                        string Temp = TmpProg.Symbols.Name;
                        prog = MVIE1.Programs.Program(Temp);
                        DataTable dt = GetAllVariablesWithProps(FetchVariable.All, prog, variableScope, ref Error);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dtRes.Merge(dt);
                        }
                    }
                }
                else if (Device.DeviceType.ToString().ToUpper() == "MARKVIES")
                {
                    MVIES1 = (IMarkVIeSDevice)Device;
                    IProgramList programList = MVIES1.Programs;
                    IProgram prog;
                    List<IUserBlockList> Tsklst = new List<IUserBlockList>();
                    List<string> TotalVar = new List<string>();
                    foreach (IProgram TmpProg in programList)
                    {
                        string Temp = TmpProg.Symbols.Name;
                        prog = MVIES1.Programs.Program(Temp);
                        DataTable dt = GetAllVariablesWithProps(FetchVariable.All, prog, variableScope, ref Error);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dtRes.Merge(dt);
                        }
                    }
                }
                return dtRes;
            }
            catch (Exception ex)
            {
                Logging("GetVariablesList", ex, "");
                Error = ex.Message.ToString();
                return new DataTable();
            }
        }
        private DataTable GetAllVariablesWithProps(FetchVariable fetchVariable, IProgram Program, VariableScope variableScope, ref string Error)
        {
            /// <summary>
            /// Gets the all properties of selected device(s).
            /// </summary>
            DataTable dtRes = new DataTable();
            try
            {
                if (fetchVariable.ToString().ToUpper() == "ALL" || fetchVariable.ToString().ToUpper() == "PROGRAMLEVEL")
                {
                    var res = from IVariable Var in Program.Variables
                              where (variableScope.ToString().ToUpper() == "ALL" || variableScope.ToString().ToUpper() == Var.Scope.ToString().ToUpper())
                              select new
                              {
                                  #region ProgramLevel
                                  VarFrom = "ProgramLevel",
                                  ProgramName = Program.Name != null ? Program.Name.ToString() : "",
                                  Name = Var.Name != null ? Var.Name.ToString() : "",
                                  Alias = Var.Alias != null ? Var.Alias.ToString() : "",
                                  Description = Var.Description != null ? Var.Description.ToString() : "",
                                  DataType = Var.DataType != null ? Var.DataType.ToString() : "",
                                  EgdPage = Var.EgdPage != null ? Var.EgdPage.ToString() : "",
                                  Access = Var.Access != null ? Var.Access.ToString() : "",
                                  ArrayLength = Var.ArrayLength != null ? Var.ArrayLength.ToString() : "",
                                  InitialValue = Var.InitialValue != null ? Var.InitialValue.ToString() : "",
                                  ArrayValues = Var.ArrayValues != null ? string.Join(",", Var.ArrayValues) : "",
                                  Units = Var.Units != null ? Var.Units.ToString() : "",
                                  FormatSpecification = Var.FormatSpecification != null ? Var.FormatSpecification.ToString() : "",
                                  Alarm = Var.Alarm != null ? Var.Alarm.ToString() : "",
                                  ControlConstant = Var.ControlConstant != null ? Var.ControlConstant.ToString() : "",
                                  DisplayHigh = Var.DisplayHigh != null ? Var.DisplayHigh.ToString() : "",
                                  DisplayLow = Var.DisplayLow != null ? Var.DisplayLow.ToString() : "",
                                  Scope = Var.Scope != null ? Var.Scope.ToString() : "",

                                  ActiveSeverity = Var.ActiveSeverity != null ? Var.ActiveSeverity.ToString() : "",
                                  Address = Var.Address != null ? Var.Address.ToString() : "",
                                  AlarmClass = Var.AlarmClass != null ? Var.AlarmClass.ToString() : "",
                                  AlarmDefinition = Var.AlarmDefinition != null ? Var.AlarmDefinition.ToString() : "",
                                  AlarmOnZero = Var.AlarmOnZero != null ? Var.AlarmOnZero.ToString() : "",
                                  AlarmShelving = Var.AlarmShelving != null ? Var.AlarmShelving.ToString() : "",
                                  AlarmShelvingMaxDuration = Var.AlarmShelvingMaxDuration != null ? Var.AlarmShelvingMaxDuration.ToString() : "",
                                  //AllConnections = Var.AllConnections != null ? Var.AllConnections.ToString() : "",
                                  AlternateLanguage = Var.AlternateLanguage != null ? Var.AlternateLanguage.ToString() : "",
                                  Attributes = Var.Attributes != null ? Var.Attributes.ToString() : "",
                                  AutoReset = Var.AutoReset != null ? Var.AutoReset.ToString() : "",
                                  ChildAlarmIDs = Var.ChildAlarmIDs != null ? Var.ChildAlarmIDs.ToString() : "",
                                  ChildAlarmNames = Var.ChildAlarmNames != null ? Var.ChildAlarmNames.ToString() : "",
                                  ChildAlarms = Var.ChildAlarms != null ? string.Join("", Var.ChildAlarms.Select(xx => xx.Name).ToList()) : "",
                                  ChildConnections = Var.ChildConnections != null ? string.Join("", Var.ChildConnections.Select(xx => xx.Name).ToList()) : "",
                                  ConnectedVariable = Var.ConnectedVariable != null ? Var.ConnectedVariable.ToString() : "",
                                  Connection = Var.Connection != null ? Var.Connection.ToString() : "",
                                  ConnectionIndex = Var.ConnectionIndex != null ? Var.ConnectionIndex.ToString() : "",
                                  ConnectionType = Var.ConnectionType != null ? Var.ConnectionType.ToString() : "",
                                  ConnectionType2 = Var.ConnectionType2 != null ? Var.ConnectionType2.ToString() : "",
                                  //ConsequenceCategory = Var.ConsequenceCategory != null ? Var.ConsequenceCategory.ToString() : "",
                                  ConsequenceOfInaction = Var.ConsequenceOfInaction != null ? Var.ConsequenceOfInaction.ToString() : "",
                                  //CumulativeIsVisibleToUser = Var.CumulativeIsVisibleToUser != null ? Var.CumulativeIsVisibleToUser.ToString() : "",
                                  DescriptionAlt = Var.DescriptionAlt != null ? Var.DescriptionAlt.ToString() : "",
                                  Device = Var.Device != null ? Var.Device.ToString() : "",
                                  DeviceName = Var.DeviceName != null ? Var.DeviceName.ToString() : "",
                                  DisplayScreen = Var.DisplayScreen != null ? Var.DisplayScreen.ToString() : "",
                                  EgdStatusVariable = Var.EgdStatusVariable != null ? Var.EgdStatusVariable.ToString() : "",
                                  EnableBQ = Var.EnableBQ != null ? Var.EnableBQ.ToString() : "",
                                  EnableDeviation = Var.EnableDeviation != null ? Var.EnableDeviation.ToString() : "",
                                  EnableH = Var.EnableH != null ? Var.EnableH.ToString() : "",
                                  EnableHH = Var.EnableHH != null ? Var.EnableHH.ToString() : "",
                                  EnableHHH = Var.EnableHHH != null ? Var.EnableHHH.ToString() : "",
                                  EnableL = Var.EnableL != null ? Var.EnableL.ToString() : "",
                                  EnableLL = Var.EnableLL != null ? Var.EnableLL.ToString() : "",
                                  EnableLLL = Var.EnableLLL != null ? Var.EnableLLL.ToString() : "",
                                  EnableRateFailure = Var.EnableRateFailure != null ? Var.EnableRateFailure.ToString() : "",
                                  EntryHighLimit = Var.EntryHighLimit != null ? Var.EntryHighLimit.ToString() : "",
                                  EntryLowLimit = Var.EntryLowLimit != null ? Var.EntryLowLimit.ToString() : "",
                                  Enumerations = Var.Enumerations != null ? Var.Enumerations.ToString() : "",
                                  EnumerationValues = Var.EnumerationValues != null ? Var.EnumerationValues.ToString() : "",
                                  Event = Var.Event != null ? Var.Event.ToString() : "",
                                  FullName = Var.FullName != null ? Var.FullName.ToString() : "",
                                  HasAttributes = Var.HasAttributes != null ? Var.HasAttributes.ToString() : "",
                                  HasDisplayHigh = Var.HasDisplayHigh != null ? Var.HasDisplayHigh.ToString() : "",
                                  HasDisplayLow = Var.HasDisplayLow != null ? Var.HasDisplayLow.ToString() : "",
                                  HasEntryHighLimit = Var.HasEntryHighLimit != null ? Var.HasEntryHighLimit.ToString() : "",
                                  HasEntryLowLimit = Var.HasEntryLowLimit != null ? Var.HasEntryLowLimit.ToString() : "",
                                  HasEnumerations = Var.HasEnumerations != null ? Var.HasEnumerations.ToString() : "",
                                  HasHealth = Var.HasHealth != null ? Var.HasHealth.ToString() : "",
                                  HmiResource = Var.HmiResource != null ? Var.HmiResource.ToString() : "",
                                  Hold = Var.Hold != null ? Var.Hold.ToString() : "",
                                  IsAlarm = Var.IsAlarm != null ? Var.IsAlarm.ToString() : "",
                                  IsAnalogAlarm = Var.IsAnalogAlarm != null ? Var.IsAnalogAlarm.ToString() : "",
                                  IsArray = Var.IsArray != null ? Var.IsArray.ToString() : "",
                                  IsEvent = Var.IsEvent != null ? Var.IsEvent.ToString() : "",
                                  IsHold = Var.IsHold != null ? Var.IsHold.ToString() : "",
                                  IsSoe = Var.IsSoe != null ? Var.IsSoe.ToString() : "",
                                  IsUndefined = Var.IsUndefined != null ? Var.IsUndefined.ToString() : "",
                                  //IsValueVisibleToUser = Var.IsValueVisibleToUser != null ? Var.IsValueVisibleToUser.ToString() : "",
                                  IsVirtualHmiPoint = Var.IsVirtualHmiPoint != null ? Var.IsVirtualHmiPoint.ToString() : "",
                                  //IsVisibleToUser = Var.IsVisibleToUser != null ? Var.IsVisibleToUser.ToString() : "",
                                  LiveArrayLength = Var.LiveArrayLength != null ? Var.LiveArrayLength.ToString() : "",
                                  LiveDataType = Var.LiveDataType != null ? Var.LiveDataType.ToString() : "",
                                  LongTermDeadband = Var.LongTermDeadband != null ? Var.LongTermDeadband.ToString() : "",
                                  LongTermDeadbandDefinition = Var.LongTermDeadbandDefinition != null ? Var.LongTermDeadbandDefinition.ToString() : "",
                                  NormalSeverity = Var.NormalSeverity != null ? Var.NormalSeverity.ToString() : "",
                                  OperatorAction = Var.OperatorAction != null ? Var.OperatorAction.ToString() : "",
                                  OperatorUrgency = Var.OperatorUrgency != null ? Var.OperatorUrgency.ToString() : "",
                                  ParentAlarmIDs = Var.ParentAlarmIDs != null ? Var.ParentAlarmIDs.ToString() : "",
                                  ParentAlarmNames = Var.ParentAlarmNames != null ? Var.ParentAlarmNames.ToString() : "",
                                  ParentAlarms = Var.ParentAlarms != null ? Var.ParentAlarms.ToString() : "",
                                  PlantArea = Var.PlantArea != null ? Var.PlantArea.ToString() : "",
                                  PointModuleName = Var.PointModuleName != null ? Var.PointModuleName.ToString() : "",
                                  PotentialCauses = Var.PotentialCauses != null ? Var.PotentialCauses.ToString() : "",
                                  Precision = Var.Precision != null ? Var.Precision.ToString() : "",
                                  PrimaryLanguage = Var.PrimaryLanguage != null ? Var.PrimaryLanguage.ToString() : "",
                                  ReadResource = Var.ReadResource != null ? Var.ReadResource.ToString() : "",
                                  RootVariable = Var.RootVariable != null ? Var.RootVariable.ToString() : "",
                                  SecondLanguageConsequenceOfInaction = Var.SecondLanguageConsequenceOfInaction != null ? Var.SecondLanguageConsequenceOfInaction.ToString() : "",
                                  SecondLanguageOperatorAction = Var.SecondLanguageOperatorAction != null ? Var.SecondLanguageOperatorAction.ToString() : "",
                                  SecondLanguageOperatorUrgency = Var.SecondLanguageOperatorUrgency != null ? Var.SecondLanguageOperatorUrgency.ToString() : "",
                                  SecondLanguagePotentialCauses = Var.SecondLanguagePotentialCauses != null ? Var.SecondLanguagePotentialCauses.ToString() : "",
                                  ShortTermDeadband = Var.ShortTermDeadband != null ? Var.ShortTermDeadband.ToString() : "",
                                  ShortTermDeadbandDefinition = Var.ShortTermDeadbandDefinition != null ? Var.ShortTermDeadbandDefinition.ToString() : "",
                                  Soe = Var.Soe != null ? Var.Soe.ToString() : "",
                                  SoeDescription = Var.SoeDescription != null ? Var.SoeDescription.ToString() : "",
                                  ValidDataTypes = Var.ValidDataTypes != null ? Var.ValidDataTypes.ToString() : "",
                                  Value = Var.Value != null ? Var.Value.ToString() : "",
                                  #endregion
                              };

                    DataTable data = res != null && res.Count() > 0 ? ConvertToDataTable(res) : new DataTable();
                    if (data.Rows.Count != 0)
                        dtRes.Merge(data);
                }
                if (fetchVariable.ToString().ToUpper() == "ALL" || fetchVariable.ToString().ToUpper() == "TASKLEVEL")
                {
                    IUserBlockList UserBlockList = Program.UserBlocks;

                    var res = from IUserBlock Block in UserBlockList
                              from IPinVariable Var in Block.Pins
                              where (variableScope.ToString().ToUpper() == "ALL" || variableScope.ToString().ToUpper() == Var.Scope.ToString().ToUpper())
                              select new
                              {
                                  #region TaskLevel
                                  VarFrom = "TaskLevel",
                                  ProgramName = Block.OwnerList != null ? Block.OwnerList.Symbols.Name : "",

                                  Name = Var.Name != null ? Var.Name.ToString() : "",
                                  Alias = Var.Alias != null ? Var.Alias.ToString() : "",
                                  Description = Var.Description != null ? Var.Description.ToString() : "",
                                  DataType = Var.DataType != null ? Var.DataType.ToString() : "",
                                  EgdPage = Var.EgdPage != null ? Var.EgdPage.ToString() : "",
                                  Access = Var.Access != null ? Var.Access.ToString() : "",
                                  ArrayLength = Var.ArrayLength != null ? Var.ArrayLength.ToString() : "",
                                  InitialValue = Var.InitialValue != null ? Var.InitialValue.ToString() : "",
                                  ArrayValues = Var.ArrayValues != null ? string.Join(",", Var.ArrayValues) : "",
                                  Units = Var.Units != null ? Var.Units.ToString() : "",
                                  FormatSpecification = Var.FormatSpecification != null ? Var.FormatSpecification.ToString() : "",
                                  Alarm = Var.Alarm != null ? Var.Alarm.ToString() : "",
                                  ControlConstant = Var.ControlConstant != null ? Var.ControlConstant.ToString() : "",
                                  DisplayHigh = Var.DisplayHigh != null ? Var.DisplayHigh.ToString() : "",
                                  DisplayLow = Var.DisplayLow != null ? Var.DisplayLow.ToString() : "",
                                  Scope = Var.Scope != null ? Var.Scope.ToString() : "",

                                  ActiveSeverity = Var.ActiveSeverity != null ? Var.ActiveSeverity.ToString() : "",
                                  Address = Var.Address != null ? Var.Address.ToString() : "",
                                  AlarmClass = Var.AlarmClass != null ? Var.AlarmClass.ToString() : "",
                                  AlarmDefinition = Var.AlarmDefinition != null ? Var.AlarmDefinition.ToString() : "",
                                  AlarmOnZero = Var.AlarmOnZero != null ? Var.AlarmOnZero.ToString() : "",
                                  AlarmShelving = Var.AlarmShelving != null ? Var.AlarmShelving.ToString() : "",
                                  AlarmShelvingMaxDuration = Var.AlarmShelvingMaxDuration != null ? Var.AlarmShelvingMaxDuration.ToString() : "",
                                  //AllConnections = Var.AllConnections != null ? Var.AllConnections.ToString() : "",
                                  AlternateLanguage = Var.AlternateLanguage != null ? Var.AlternateLanguage.ToString() : "",
                                  Attributes = Var.Attributes != null ? Var.Attributes.ToString() : "",
                                  AutoReset = Var.AutoReset != null ? Var.AutoReset.ToString() : "",
                                  ChildAlarmIDs = Var.ChildAlarmIDs != null ? Var.ChildAlarmIDs.ToString() : "",
                                  ChildAlarmNames = Var.ChildAlarmNames != null ? Var.ChildAlarmNames.ToString() : "",
                                  ChildAlarms = Var.ChildAlarms != null ? Var.ChildAlarms.ToString() : "",
                                  ChildConnections = Var.ChildConnections != null ? Var.ChildConnections.ToString() : "",
                                  ConnectedVariable = Var.ConnectedVariable != null ? Var.ConnectedVariable.ToString() : "",
                                  Connection = Var.Connection != null ? Var.Connection.ToString() : "",
                                  ConnectionIndex = Var.ConnectionIndex != null ? Var.ConnectionIndex.ToString() : "",
                                  ConnectionType = Var.ConnectionType != null ? Var.ConnectionType.ToString() : "",
                                  ConnectionType2 = Var.ConnectionType2 != null ? Var.ConnectionType2.ToString() : "",
                                  //ConsequenceCategory = Var.ConsequenceCategory != null ? Var.ConsequenceCategory.ToString() : "",
                                  ConsequenceOfInaction = Var.ConsequenceOfInaction != null ? Var.ConsequenceOfInaction.ToString() : "",
                                  //CumulativeIsVisibleToUser = Var.CumulativeIsVisibleToUser != null ? Var.CumulativeIsVisibleToUser.ToString() : "",
                                  DescriptionAlt = Var.DescriptionAlt != null ? Var.DescriptionAlt.ToString() : "",
                                  Device = Var.Device != null ? Var.Device.ToString() : "",
                                  DeviceName = Var.DeviceName != null ? Var.DeviceName.ToString() : "",
                                  DisplayScreen = Var.DisplayScreen != null ? Var.DisplayScreen.ToString() : "",
                                  EgdStatusVariable = Var.EgdStatusVariable != null ? Var.EgdStatusVariable.ToString() : "",
                                  EnableBQ = Var.EnableBQ != null ? Var.EnableBQ.ToString() : "",
                                  EnableDeviation = Var.EnableDeviation != null ? Var.EnableDeviation.ToString() : "",
                                  EnableH = Var.EnableH != null ? Var.EnableH.ToString() : "",
                                  EnableHH = Var.EnableHH != null ? Var.EnableHH.ToString() : "",
                                  EnableHHH = Var.EnableHHH != null ? Var.EnableHHH.ToString() : "",
                                  EnableL = Var.EnableL != null ? Var.EnableL.ToString() : "",
                                  EnableLL = Var.EnableLL != null ? Var.EnableLL.ToString() : "",
                                  EnableLLL = Var.EnableLLL != null ? Var.EnableLLL.ToString() : "",
                                  EnableRateFailure = Var.EnableRateFailure != null ? Var.EnableRateFailure.ToString() : "",
                                  EntryHighLimit = Var.EntryHighLimit != null ? Var.EntryHighLimit.ToString() : "",
                                  EntryLowLimit = Var.EntryLowLimit != null ? Var.EntryLowLimit.ToString() : "",
                                  Enumerations = Var.Enumerations != null ? Var.Enumerations.ToString() : "",
                                  EnumerationValues = Var.EnumerationValues != null ? Var.EnumerationValues.ToString() : "",
                                  Event = Var.Event != null ? Var.Event.ToString() : "",
                                  FullName = Var.FullName != null ? Var.FullName.ToString() : "",
                                  HasAttributes = Var.HasAttributes != null ? Var.HasAttributes.ToString() : "",
                                  HasDisplayHigh = Var.HasDisplayHigh != null ? Var.HasDisplayHigh.ToString() : "",
                                  HasDisplayLow = Var.HasDisplayLow != null ? Var.HasDisplayLow.ToString() : "",
                                  HasEntryHighLimit = Var.HasEntryHighLimit != null ? Var.HasEntryHighLimit.ToString() : "",
                                  HasEntryLowLimit = Var.HasEntryLowLimit != null ? Var.HasEntryLowLimit.ToString() : "",
                                  HasEnumerations = Var.HasEnumerations != null ? Var.HasEnumerations.ToString() : "",
                                  HasHealth = Var.HasHealth != null ? Var.HasHealth.ToString() : "",
                                  HmiResource = Var.HmiResource != null ? Var.HmiResource.ToString() : "",
                                  Hold = Var.Hold != null ? Var.Hold.ToString() : "",
                                  IsAlarm = Var.IsAlarm != null ? Var.IsAlarm.ToString() : "",
                                  IsAnalogAlarm = Var.IsAnalogAlarm != null ? Var.IsAnalogAlarm.ToString() : "",
                                  IsArray = Var.IsArray != null ? Var.IsArray.ToString() : "",
                                  IsEvent = Var.IsEvent != null ? Var.IsEvent.ToString() : "",
                                  IsHold = Var.IsHold != null ? Var.IsHold.ToString() : "",
                                  IsSoe = Var.IsSoe != null ? Var.IsSoe.ToString() : "",
                                  IsUndefined = Var.IsUndefined != null ? Var.IsUndefined.ToString() : "",
                                  //IsValueVisibleToUser = Var.IsValueVisibleToUser != null ? Var.IsValueVisibleToUser.ToString() : "",
                                  IsVirtualHmiPoint = Var.IsVirtualHmiPoint != null ? Var.IsVirtualHmiPoint.ToString() : "",
                                  //IsVisibleToUser = Var.IsVisibleToUser != null ? Var.IsVisibleToUser.ToString() : "",
                                  LiveArrayLength = Var.LiveArrayLength != null ? Var.LiveArrayLength.ToString() : "",
                                  LiveDataType = Var.LiveDataType != null ? Var.LiveDataType.ToString() : "",
                                  LongTermDeadband = Var.LongTermDeadband != null ? Var.LongTermDeadband.ToString() : "",
                                  LongTermDeadbandDefinition = Var.LongTermDeadbandDefinition != null ? Var.LongTermDeadbandDefinition.ToString() : "",
                                  NormalSeverity = Var.NormalSeverity != null ? Var.NormalSeverity.ToString() : "",
                                  OperatorAction = Var.OperatorAction != null ? Var.OperatorAction.ToString() : "",
                                  OperatorUrgency = Var.OperatorUrgency != null ? Var.OperatorUrgency.ToString() : "",
                                  ParentAlarmIDs = Var.ParentAlarmIDs != null ? Var.ParentAlarmIDs.ToString() : "",
                                  ParentAlarmNames = Var.ParentAlarmNames != null ? Var.ParentAlarmNames.ToString() : "",
                                  ParentAlarms = Var.ParentAlarms != null ? Var.ParentAlarms.ToString() : "",
                                  PlantArea = Var.PlantArea != null ? Var.PlantArea.ToString() : "",
                                  PointModuleName = Var.PointModuleName != null ? Var.PointModuleName.ToString() : "",
                                  PotentialCauses = Var.PotentialCauses != null ? Var.PotentialCauses.ToString() : "",
                                  Precision = Var.Precision != null ? Var.Precision.ToString() : "",
                                  PrimaryLanguage = Var.PrimaryLanguage != null ? Var.PrimaryLanguage.ToString() : "",
                                  ReadResource = Var.ReadResource != null ? Var.ReadResource.ToString() : "",
                                  RootVariable = Var.RootVariable != null ? Var.RootVariable.ToString() : "",
                                  SecondLanguageConsequenceOfInaction = Var.SecondLanguageConsequenceOfInaction != null ? Var.SecondLanguageConsequenceOfInaction.ToString() : "",
                                  SecondLanguageOperatorAction = Var.SecondLanguageOperatorAction != null ? Var.SecondLanguageOperatorAction.ToString() : "",
                                  SecondLanguageOperatorUrgency = Var.SecondLanguageOperatorUrgency != null ? Var.SecondLanguageOperatorUrgency.ToString() : "",
                                  SecondLanguagePotentialCauses = Var.SecondLanguagePotentialCauses != null ? Var.SecondLanguagePotentialCauses.ToString() : "",
                                  ShortTermDeadband = Var.ShortTermDeadband != null ? Var.ShortTermDeadband.ToString() : "",
                                  ShortTermDeadbandDefinition = Var.ShortTermDeadbandDefinition != null ? Var.ShortTermDeadbandDefinition.ToString() : "",
                                  Soe = Var.Soe != null ? Var.Soe.ToString() : "",
                                  SoeDescription = Var.SoeDescription != null ? Var.SoeDescription.ToString() : "",
                                  ValidDataTypes = Var.ValidDataTypes != null ? Var.ValidDataTypes.ToString() : "",
                                  Value = Var.Value != null ? Var.Value.ToString() : "",
                                  #endregion
                              };

                    DataTable data = res != null && res.Count() > 0 ? ConvertToDataTable(res) : new DataTable();
                    if (data.Rows.Count != 0)
                        dtRes.Merge(data);
                }
                return dtRes;
            }
            catch (Exception ex)
            {
                Logging("GetAllVariablesWithProps", ex, "");
                Error = ex.Message.ToString();
                return dtRes;
            }
        }
        private DataTable ConvertToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
        private void Logging(string FunctionName, Exception ex, string Error)
        {
            try
            {
                //Change the Path into the working directory.
                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("\n\nLOG ENTRY:\n");
                sbLog.Append(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + "\n");
                sbLog.Append(FunctionName + "\n");
                sbLog.Append((ex != null ? ex.ToString() : Error) + "\n");
                sbLog.Append("---------------------------------------------------------------------------------------------------------------------------------");

                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                string logFilePath = "C:\\Logs\\";
                logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                log.WriteLine(sbLog.ToString());
                log.Close();
            }
            catch (Exception e)
            {

            }
        }
        public DataTable GetEgdPageWithProps(IDevice device, ref string Error)
        {
            DataTable dtResults = new DataTable();
            try
            {
                IEgdConfig egdConfig = device.EgdConfig;
                IEgdPageList egdPageList = egdConfig.ProducedPages;
                var res = from IEgdPage page in egdPageList
                          select new
                          {
                              Name = page.Name != null ? page.Name.ToString() : "",
                              DeviceName = device.Name != null ? device.Name.ToString() : "",
                              StatusPage = page.StatusPage != null ? page.StatusPage.ToString() : "",
                              AllowEdits = page.AllowEdits != null ? page.AllowEdits.ToString() : "",
                              AutoConfigure = page.AutoConfigure != null ? page.AutoConfigure.ToString() : "",
                              Available = page.Available != null ? page.Available.ToString() : "",
                              DefaultPage = page.DefaultPage != null ? page.DefaultPage.ToString() : "",
                              Description = page.Description != null ? page.Description.ToString() : "",
                              Destination = page.Destination != null ? page.Destination.ToString() : "",
                              Mode = page.Destination != null ? page.Destination.ToString() : "",
                              ExchangeId = page.Exchanges != null ? string.Join(",", page.Exchanges.Select(xx => xx.ExchangeId).ToList()) : "",
                              ConfigurationTime = page.Exchanges != null ? string.Join(",", page.Exchanges.Select(xx => xx.ConfigurationTime).ToList()) : "",
                              DataLength = page.Exchanges != null ? string.Join(",", page.Exchanges.Select(xx => xx.DataLength).ToList()) : "",
                              SignatureMajor = page.Exchanges != null ? string.Join(",", page.Exchanges.Select(xx => xx.SignatureMajor).ToList()) : "",
                              SignatureMinor = page.Exchanges != null ? string.Join(",", page.Exchanges.Select(xx => xx.SignatureMinor).ToList()) : "",

                              DestinationAddresses = page.DestinationAddresses != null ? page.DestinationAddresses.ToString() : "",
                              DirectedIPAddress = page.DirectedIPAddress != null ? page.DirectedIPAddress.ToString() : "",
                              Ethernet0 = page.Ethernet0 != null ? page.Ethernet0.ToString() : "",
                              Ethernet1 = page.Ethernet1 != null ? page.Ethernet1.ToString() : "",
                              Ethernet2 = page.Ethernet2 != null ? page.Ethernet2.ToString() : "",
                              Ethernet3 = page.Ethernet3 != null ? page.Ethernet3.ToString() : "",
                              Exchanges = page.Exchanges != null ? string.Join(",", page.Exchanges.Select(xx => xx.ExchangeId).ToList()) : "",
                              HealthTimeoutMultiplier = page.HealthTimeoutMultiplier != null ? page.HealthTimeoutMultiplier.ToString() : "",
                              IndexableChildren = page.IndexableChildren != null ? string.Join(",", page.IndexableChildren.Select(xx => xx.IndexableChildren).ToList()) : "",
                              IndexableProperties = page.IndexableProperties != null ? string.Join(",", page.IndexableChildren.Select(xx => xx.IndexableProperties).ToList()) : "",
                              LayoutMode = page.LayoutMode != null ? page.LayoutMode.ToString() : "",
                              Location = page.Location != null ? page.Location.ToString() : "",
                              LocatorID = page.LocatorID != null ? page.LocatorID.ToString() : "",
                              MinimumExchangeLength = page.MinimumExchangeLength != null ? page.MinimumExchangeLength.ToString() : "",
                              Multiplier = page.Multiplier != null ? page.Multiplier.ToString() : "",
                              NumExchanges = page.NumExchanges != null ? page.NumExchanges.ToString() : "",
                              ParentObject = page.ParentObject != null ? page.ParentObject.ParentObject.ToString() : "",
                              Period = page.Period != null ? page.Period.ToString() : "",
                              PrimaryProducerName = page.PrimaryProducerName != null ? page.PrimaryProducerName.ToString() : "",
                              ReattachPageVarsAfterPageRename = page.ReattachPageVarsAfterPageRename != null ? page.ReattachPageVarsAfterPageRename.ToString() : "",
                              //Redundancy = page.Redundancy != null ? page.Redundancy.ToString() : "",
                              SecondaryProducerId = page.SecondaryProducerId != null ? page.SecondaryProducerId.ToString() : "",
                              Skew = page.Skew != null ? page.Skew.ToString() : "",
                              StartingExchangeId = page.StartingExchangeId != null ? page.StartingExchangeId.ToString() : "",
                              UseVarAtOffsetZeroForHealth = page.UseVarAtOffsetZeroForHealth != null ? page.UseVarAtOffsetZeroForHealth.ToString() : "",
                          };

                return dtResults = ConvertToDataTable(res);
            }
            catch (Exception ex)
            {
                Logging("GetEgdPageWithProps", ex, "");
                Error = ex.Message.ToString();
                return dtResults;
            }
        }
        public bool RemoveEGDPage(IDevice device, string EGDPageName, ref string Error)
        {
            try
            {
                if (device.EgdConfig.ProducedPages.Contains(EGDPageName.ToString()))
                {
                    device.EgdConfig.ProducedPages.Remove(device.EgdConfig.ProducedPages[EGDPageName.ToString()]);
                    //device.Save();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                Logging("RemoveEGDPage", ex, "");
                Error = ex.Message.ToString();
                return false;
            }
        }
        public bool SetEGDPage(IDevice device, string EGDPageName, ref string Error, [Optional] EGDProps eGDProps)
        {
            try
            {
                IEgdConfig egdConfig = device.EgdConfig;
                IEgdPageList egdPageList = egdConfig.ProducedPages;
                if (egdPageList.Contains(EGDPageName))
                {
                    //if (eGDProps != null && eGDProps.Name != null && eGDProps.Name != "")
                    //{
                    if (eGDProps.Name != null && eGDProps.Name != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].Name = eGDProps.Name.ToString();
                    if (eGDProps.Ethernet0 != null && eGDProps.Ethernet0 != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].Ethernet0 = Convert.ToBoolean(eGDProps.Ethernet0);
                    if (eGDProps.Destination != null && eGDProps.Destination != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].Destination = eGDProps.Destination != null ? (eGDProps.Destination.ToUpper() == "BROADCAST" ? GeIndsysNetworkCoe.EgdConfig.EgdDestinationGirth.Broadcast :
                                                                                         eGDProps.Destination.ToUpper() == "UNICAST" ? GeIndsysNetworkCoe.EgdConfig.EgdDestinationGirth.Unicast : GeIndsysNetworkCoe.EgdConfig.EgdDestinationGirth.Multicast) : GeIndsysNetworkCoe.EgdConfig.EgdDestinationGirth.Broadcast;
                    if (eGDProps.LayoutMode != null && eGDProps.LayoutMode != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].LayoutMode = eGDProps.LayoutMode != null ? (eGDProps.LayoutMode.ToUpper() == "AUTO" ? GeIndsysNetworkCoe.EgdConfig.EgdPageLayoutMode.Auto :
                                                                                        eGDProps.LayoutMode.ToUpper() == "FIXED" ? GeIndsysNetworkCoe.EgdConfig.EgdPageLayoutMode.Fixed : GeIndsysNetworkCoe.EgdConfig.EgdPageLayoutMode.Manual) : GeIndsysNetworkCoe.EgdConfig.EgdPageLayoutMode.Auto;

                    if (eGDProps.MinimumExchangeLength != null && eGDProps.MinimumExchangeLength != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].MinimumExchangeLength = Convert.ToUInt32(eGDProps.MinimumExchangeLength);
                    if (eGDProps.Multiplier != null && eGDProps.Multiplier != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].Multiplier = Convert.ToInt32(eGDProps.Multiplier);
                    if (eGDProps.Skew != null && eGDProps.Skew != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].Skew = Convert.ToInt32(eGDProps.Skew);
                    if (eGDProps.StartingExchangeId != null && eGDProps.StartingExchangeId != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].StartingExchangeId = Convert.ToUInt32(eGDProps.StartingExchangeId);
                    if (eGDProps.Description != null && eGDProps.Description != "")
                        device.EgdConfig.ProducedPages[EGDPageName.ToString()].Description = eGDProps.Description;
                    //}
                }
                else
                {
                    device.EgdConfig.ProducedPages.Add(EGDPageName.ToString());
                }
                //device.Save();
                return true;
            }
            catch (Exception ex)
            {
                Logging("SetEGDPage", ex, "");
                Error = ex.Message.ToString();
                return false;
            }
        }
        public string GetDeviceVersion(IDevice device)
        {
            string Version = string.Empty;
            try
            {
                Version = device.ProductVersion.ToString();
                return Version;
            }
            catch (Exception ex)
            {
                return Version;
            }
        }
        public string GetDeviceType(IDevice device)
        {
            string Type = string.Empty;
            try
            {
                Type = device.DeviceType.ToString();
                return Type;
            }
            catch (Exception ex)
            {
                return Type;
            }
        }

        public bool SaveDevices(Hashtable hshDevices)
        {
            try
            {
                foreach (DictionaryEntry Item in hshDevices)
                {
                    IDevice device = (IDevice)Item.Value;
                    device.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    public class EGDProps
    {
        public string Name { get; set; }
        public string Ethernet0 { get; set; }
        public string Destination { get; set; }
        public string LayoutMode { get; set; }
        public string MinimumExchangeLength { get; set; }
        public string Multiplier { get; set; }
        public string Skew { get; set; }
        public string StartingExchangeId { get; set; }
        public string Description { get; set; }
    }
}
