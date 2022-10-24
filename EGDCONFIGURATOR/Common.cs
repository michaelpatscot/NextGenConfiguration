using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EGDCONFIGURATOR
{
    class Common
    {
        public static Tuple<List<string>, List<string>, string> ReadToolboxMarkDevices(string filePath)
        {
            List<string> MarkVIeDevs = new List<string>();
            List<string> MarkVIeSDevs = new List<string>();
            string msg = "";
            XmlDocument xDoc = new XmlDocument();
            using (XmlReader xReader = new XmlTextReader(filePath))
            {
                xDoc.Load(xReader);
            }

            //check that the file is a real tcw
            if (!xDoc.ChildNodes.Cast<XmlNode>().Any(y => y.Name == "GeCssClass" && y.Value != null && y.Value.ToString().Contains("SystemConfig.SystemConfig"))
                || !xDoc.ChildNodes.Cast<XmlNode>().Any(z => z.Name == "SystemConfig"))
            {
                //this is not a tcw
                msg = "This is not a valid ToolboxST project file!";
                return new Tuple<List<string>, List<string>, string>(MarkVIeDevs, MarkVIeSDevs, msg);
            }

            //retrieve Devices
            XmlNodeList tcwDevices = xDoc.SelectNodes("descendant::DeviceInfo");
            if (tcwDevices.Count < 1)
            {
                msg = "No device found in the proposed ToolboxST project file!";
                return new Tuple<List<string>, List<string>, string>(MarkVIeDevs, MarkVIeSDevs, msg);
            }

            foreach (XmlNode x in tcwDevices)
            {
                if (x.Attributes["type"].Value.ToString() == "MarkVIe")
                {
                    MarkVIeDevs.Add(x.Attributes["name"].Value.ToString());
                }
                if (x.Attributes["type"].Value.ToString() == "MarkVIeS")
                {
                    MarkVIeSDevs.Add(x.Attributes["name"].Value.ToString());
                }
            }

            return new Tuple<List<string>, List<string>, string>(MarkVIeDevs, MarkVIeSDevs, msg);
        }
    }

    [DefaultPropertyAttribute("Job Details")]
    public class Jobdetails
    {
        public string _Filepath;
        public string _JobNumber;
        public string _Company;
        public string _User;
        public string _Errors;
        public string _Messages;
        public string _Warnings;
        [CategoryAttribute("Job Configuarion"), DescriptionAttribute("Describes the job configuration"), ReadOnly(true)]
        public string Filepath
        {
            get { return _Filepath; }
            set { _Filepath = value; }
        }
        [CategoryAttribute("Details"), DescriptionAttribute("Describes the job number"), ReadOnly(true)]
        public string JobNumber
        {
            get { return _JobNumber; }
            set { _JobNumber = value; }
        }
        [CategoryAttribute("Details"), DescriptionAttribute("Name of the company"), ReadOnly(true)]
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }

        }
        [CategoryAttribute("Details"), DescriptionAttribute("Name of the user"), ReadOnly(true)]
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the errors"), ReadOnly(true)]
        public string Errors
        {
            get { return _Errors; }
            set { _Errors = value; }
        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the messages"), ReadOnly(true)]
        public string Messages
        {
            get { return _Messages; }
            set { _Messages = value; }

        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the warinings"), ReadOnly(true)]
        public string Warnings
        {
            get { return _Warnings; }
            set { _Warnings = value; }
        }

    }

    [DefaultPropertyAttribute("ToolBox ST")]
    public class ToolboxST
    {
        public string _Filepath;
        public string _TCWVersion;
        public string _AppVersion;
        public string _Errors;
        public string _Messages;
        public string _Warnings;
        [CategoryAttribute("ToolboxST Software"), DescriptionAttribute("File path of the toolbox ST"), ReadOnly(true)]
        public string Filepath
        {
            get { return _Filepath; }
            set { _Filepath = value; }
        }
        [CategoryAttribute("Details"), DescriptionAttribute("Originally created toolbox ST version"), ReadOnly(true)]
        public string TCWVersion
        {
            get { return _TCWVersion; }
            set { _TCWVersion = value; }
        }
        [CategoryAttribute("Details"), DescriptionAttribute("The version user selects to work with"), ReadOnly(true)]
        public string APPVersion
        {
            get { return _AppVersion; }
            set { _AppVersion = value; }

        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the errors"), ReadOnly(true)]
        public string Errors
        {
            get { return _Errors; }
            set { _Errors = value; }
        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the messages"), ReadOnly(true)]
        public string Messages
        {
            get { return _Messages; }
            set { _Messages = value; }

        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the warinings"), ReadOnly(true)]
        public string Warnings
        {
            get { return _Warnings; }
            set { _Warnings = value; }
        }

    }

    [DefaultPropertyAttribute("EGD Properties")]
    public class EGDProperies
    {
        string PageName = string.Empty;

        public enum mode
        {
            Broadcast,
            Unicast,
            Multicast
        }
        public enum layoutmode
        {
            Auto,
            Manual
        }

        public EGDProperies(string EGDPage)
        {
            PageName = EGDPage;
        }

        public string _Name = string.Empty;
        public string _DeviceName = string.Empty;
        public string _StatusPage = string.Empty;
        public string _AllowEdits = string.Empty;
        public string _AutoConfigure = string.Empty;
        public string _Available = string.Empty;
        public string _DefaultPage = string.Empty;
        public string _Description = string.Empty;
        public string _Destination = string.Empty;
        public string _DestinationAddresses = string.Empty;
        public string _DirectedIPAddress = string.Empty;
        public bool _Ethernet0 = false;
        public string _Ethernet1 = string.Empty;
        public string _Ethernet2 = string.Empty;
        public string _Ethernet3 = string.Empty;
        public string _Exchanges = string.Empty;
        public string _HealthTimeoutMultiplier = string.Empty;
        public string _IndexableChildren = string.Empty;
        public string _IndexableProperties = string.Empty;
        public string _LayoutMode = string.Empty;
        //public string _Mode = string.Empty;
        public string _Location = string.Empty;
        public string _LocatorID = string.Empty;
        public string _MinimumExchangeLength = string.Empty;
        public string _Multiplier = string.Empty;
        public string _NumExchanges = string.Empty;
        public string _ParentObject = string.Empty;
        public string _Period = string.Empty;
        public string _PrimaryProducerName = string.Empty;
        public string _ReattachPageVarsAfterPageRename =string.Empty;
        public string _Redundancy = string.Empty;
        public string _SecondaryProducerId = string.Empty;
        public string _Skew = string.Empty;
        public string _StartingExchangeId = string.Empty;
        public string _UseVarAtOffsetZeroForHealth = string.Empty;
        public mode _Mode;
        public layoutmode _layoutmode;
        public string _ExchangeId = string.Empty;
        public string _ConfigurationTime = string.Empty;
        public string _DataLength = string.Empty;
        public string _Signature = string.Empty;
        
        


        [CategoryAttribute("Setup"), DescriptionAttribute("Name of the EGD Page"), ReadOnly(false)]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string DeviceName
        {
            get { return _DeviceName; }
            set { _DeviceName = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("This is the status page for the status monitoring signals."), ReadOnly(true)]
        public string StatusPage
        {
            get { return _StatusPage; }
            set { _StatusPage = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string AllowEdits
        {
            get { return _AllowEdits; }
            set { _AllowEdits = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string AutoConfigure
        {
            get { return _AutoConfigure; }
            set { _AutoConfigure = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string Available
        {
            get { return _Available; }
            set { _Available = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("This is the default page for the standard signals."), ReadOnly(true)]
        public string DefaultPage {
            get { return _DefaultPage; }
            set { _DefaultPage = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("Page description."), ReadOnly(false)]
        public string Description {
            get { return _Description; }
            set { _Description = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string DestinationAddresses
        {
            get { return _DestinationAddresses; }
            set { _DestinationAddresses = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string DirectedIPAddress
        {
            get { return _DirectedIPAddress; }
            set { _DirectedIPAddress = value; }
        }

        [CategoryAttribute("Destination"), DescriptionAttribute("EGD will be transmitted on Ethernet Adaptor 0."), ReadOnly(false)]
        public bool Ethernet0 {
            get { return _Ethernet0; }
            set { _Ethernet0 = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string Ethernet1 {
            get { return _Ethernet1; }
            set { _Ethernet1 = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string Ethernet2 {
            get { return _Ethernet2; }
            set { _Ethernet2 = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string Ethernet3 {
            get { return _Ethernet3; }
            set { _Ethernet3 = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute("Number of Exchanges in this page. Updated after a build."), ReadOnly(true)]
        public string Exchanges
        {
            get { return _Exchanges; }
            set { _Exchanges = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string HealthTimeoutMultiplier
        {
            get { return _HealthTimeoutMultiplier; }
            set { _HealthTimeoutMultiplier = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string IndexableChildren
        {
            get { return _IndexableChildren; }
            set { _IndexableChildren = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string IndexableProperties
        {
            get { return _IndexableProperties; }
            set { _IndexableProperties = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("Page Layout Mode.\nAuto = exchange numbers and offsets are automatically assigned at build time.\nManual = exchange numbers and offsets can be entered manually. "), ReadOnly(false)]
        public layoutmode LayoutMode
        {
            get { return _layoutmode; }
            set { _layoutmode = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string LocatorID
        {
            get { return _LocatorID; }
            set { _LocatorID = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("Minimum length of the exchanges on this page. Some components only look at the length of the exchange. This property can be set to a value larger than the current size of the exchange and then as variables are added, the component will continue to receive the exchange."), ReadOnly(false)]
        public string MinimumExchangeLength
        {
            get { return _MinimumExchangeLength; }
            set { _MinimumExchangeLength = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("The control frame period is multiplied by this value to obtain the EGD page period."), ReadOnly(false)]
        public string Multiplier
        {
            get { return _Multiplier; }
            set { _Multiplier = value; }
        }

        [CategoryAttribute("Destination"), DescriptionAttribute("The page is sent to all EGD Nodes"), ReadOnly(false)]
        public mode Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string NumExchanges {
            get { return _NumExchanges; }
            set { _NumExchanges = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string ParentObject
        {
            get { return _ParentObject; }
            set { _ParentObject = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("The transmission period of the page"), ReadOnly(true)]
        public string Period
        {
            get { return _Period; }
            set { _Period = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string PrimaryProducerName
        {
            get { return _PrimaryProducerName; }
            set { _PrimaryProducerName = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string ReattachPageVarsAfterPageRename
        {
            get { return _ReattachPageVarsAfterPageRename; }
            set { _ReattachPageVarsAfterPageRename = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string Redundancy
        {
            get { return _Redundancy; }
            set { _Redundancy = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string SecondaryProducerId
        {
            get { return _SecondaryProducerId; }
            set { _SecondaryProducerId = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("Skew is used to prevent exchanges with the same period from being produced at exactly the same instant(nanoseconds)."), ReadOnly(false)]
        public string Skew
        {
            get { return _Skew; }
            set { _Skew = value; }
        }

        [CategoryAttribute("Setup"), DescriptionAttribute("The exchange ID is used for the first exchange on this page. Each additional exchange will be increment from this number."), ReadOnly(false)]
        public string StartingExchangeId
        {
            get { return _StartingExchangeId; }
            set { _StartingExchangeId = value; }
        }

        [CategoryAttribute(""), DescriptionAttribute(""), ReadOnly(true)]
        public string UseVarAtOffsetZeroForHealth
        {
            get { return _UseVarAtOffsetZeroForHealth; }
            set { _UseVarAtOffsetZeroForHealth = value; }
        }

        [CategoryAttribute("Configuration"), DescriptionAttribute(""), ReadOnly(true)]
        public string ExchangeId
        {
            get { return _ExchangeId; }
            set { _ExchangeId = value; }
        }
        [CategoryAttribute("Configuration"), DescriptionAttribute(""), ReadOnly(true)]
        public string ConfigurationTime
        {
            get { return _ConfigurationTime; }
            set { _ConfigurationTime = value; }
        }
        [CategoryAttribute("Configuration"), DescriptionAttribute(""), ReadOnly(true)]
        public string Length
        {
            get { return _DataLength; }
            set { _DataLength = value; }
        }
        [CategoryAttribute("Configuration"), DescriptionAttribute(""), ReadOnly(true)]
        public string Signature
        {
            get { return _Signature; }
            set { _Signature = value; }
        }
    }

    [DefaultPropertyAttribute("Device Details")]
    public class DeviceDetails
    {
        public string _DeviceName;
        public string _DeviceType;
        public string _DeviceVersion;
        public string _Errors;
        public string _Messages;
        public string _Warnings;
       
        [CategoryAttribute("Details"), DescriptionAttribute("Name of the device."), ReadOnly(true)]
        public string DeviceName
        {
            get { return _DeviceName; }
            set { _DeviceName = value; }
        }
        [CategoryAttribute("Details"), DescriptionAttribute("Type of the device."), ReadOnly(true)]
        public string DeviceType
        {
            get { return _DeviceType; }
            set { _DeviceType = value; }

        }
        [CategoryAttribute("Details"), DescriptionAttribute("Version number of the device."), ReadOnly(true)]
        public string DeviceVersion
        {
            get { return _DeviceVersion; }
            set { _DeviceVersion = value; }
        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the errors"), ReadOnly(true)]
        public string Errors
        {
            get { return _Errors; }
            set { _Errors = value; }
        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the messages"), ReadOnly(true)]
        public string Messages
        {
            get { return _Messages; }
            set { _Messages = value; }

        }
        [CategoryAttribute("Information"), DescriptionAttribute("Information about the warinings"), ReadOnly(true)]
        public string Warnings
        {
            get { return _Warnings; }
            set { _Warnings = value; }
        }

    }
}
