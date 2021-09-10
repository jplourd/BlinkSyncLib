using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlinkSyncLib;

namespace BlinkSync.CLI
{
    class RunBlinkSync
    {
        #region Properties

        /// <summary>
        /// Directory to keep in sync
        /// </summary>
        public string TemplateFilesSrcDirectory { get; private set; }

        /// <summary>
        /// Directory to sync to. Delete added files
        /// </summary>
        public string TemplateFilesDestDirectory { get; private set; }

        /// <summary>
        /// Configuration parameters to the sync class
        /// </summary>
        public InputParams TemplateFilesInputParams { get; private set; }


        public string TemplateFilesConfigurationPathName { get; private set; }

        public BlinkSyncConfig TemplateFilesConfiguration { get; private set; }
        #endregion

        #region Contructors

        public  RunBlinkSync()
        { }

        public RunBlinkSync(string configPathFile)
            :this()
        {
            TemplateFilesConfigurationPathName = configPathFile;
            TemplateFilesConfiguration =
                new BlinkSyncConfig(TemplateFilesConfigurationPathName);
            TemplateFilesSrcDirectory =
                TemplateFilesConfiguration.TemplateFilesSourceDirectory;
            TemplateFilesDestDirectory =
                TemplateFilesConfiguration.TemplateFilesDestinationDirectory;

            TemplateFilesInputParams =
                new InputParams();
            TemplateFilesInputParams.DeleteFromDest = true;
        }
        #endregion


        static void Main(string[] args)
        {
            RunBlinkSync SyncTemplateFileDirectory =
                new RunBlinkSync(args[0]);

            // perform the directory sync
            SyncResults results = new SyncResults();
            results = new Sync(
                SyncTemplateFileDirectory.TemplateFilesSrcDirectory,
                SyncTemplateFileDirectory.TemplateFilesDestDirectory
                ).Start(SyncTemplateFileDirectory.TemplateFilesInputParams);

            var filenumber = results.FilesCopied;
            var filedel = results.FilesDeleted;

        }
    }
}
