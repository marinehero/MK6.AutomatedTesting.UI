using System.Configuration;

namespace MK6.AutomatedTesting.UI.Configuration
{
    public class DriverConfigurationSection : ConfigurationSection
    {
        private const string BrowserKey = "browser";

        private const string ServerSourceKey = "serverSource";

        private const string RemoteUrlKey = "remoteUrl";

        private const string RemoteBrowerKey = "remoteBrowser";

        private const string RemoteBrowserVersionKey = "remoteBrowserVersion";

        private const string CommandArgumentKey = "commandArgument";

        [ConfigurationProperty(BrowserKey, IsRequired = true)]
        public string Browser
        {
            get
            {
                return this[BrowserKey].ToString();
            }
            set
            {
                this[BrowserKey] = value.ToString();
            }
        }

        [ConfigurationProperty(ServerSourceKey, IsRequired = false, DefaultValue = "")]
        public string ServerSource
        {
            get
            {
                return this[ServerSourceKey].ToString();
            }
            set
            {
                this[ServerSourceKey] = value;
            }
        }

        [ConfigurationProperty(CommandArgumentKey, IsRequired = false, DefaultValue = "")]
        public string CommandArgument
        {
            get
            {
                return this[CommandArgumentKey].ToString();
            }
            set
            {
                this[CommandArgumentKey] = value;
            }
        }

        [ConfigurationProperty(RemoteUrlKey, IsRequired = false, DefaultValue = "")]
        public string RemoteUrl
        {
            get
            {
                return this[RemoteUrlKey].ToString();
            }
            set
            {
                this[RemoteUrlKey] = value;
            }
        }

        [ConfigurationProperty(RemoteBrowerKey, IsRequired = false, DefaultValue = "")]
        public string RemoteBrowser
        {
            get
            {
                return this[RemoteBrowerKey].ToString();
            }
            set
            {
                this[RemoteBrowerKey] = value;
            }
        }

        [ConfigurationProperty(RemoteBrowserVersionKey, IsRequired = false, DefaultValue = "")]
        public string RemoteBrowserVersion
        {
            get
            {
                return this[RemoteBrowserVersionKey].ToString();
            }
            set
            {
                this[RemoteBrowserVersionKey] = value;
            }
        }
    }
}
