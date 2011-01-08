// Copyright 2008-2010 Andrej Repin aka Gremlin2
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using Tanone.Common;
using Tanone.Common.Interfaces;
using Tanone.FB2Librarian.AbsPlugin;
using System.IO;

[assembly: Plugin("Book Scanner Plugin", new[] { "ImportPlugin" })]
[assembly: PlugInClass("ImportPlugin", "Book Scanner Plugin", typeof(Gremlin.FB2Librarian.Import.ImportPlugin))]

namespace Gremlin.FB2Librarian.Import
{
    public class ImportPlugin : Fb2AbsPlugin
    {
        private readonly string defaultSettings =
            @"<Plugin name='ImportPlugin' caption='Book Scanner Plugin'>
                <Settings>
                    <Setting name='DontCheckForDuplicate' caption='Dont check for book duplicate' value='False' visible='1'/>
                </Settings>
                <Actions>
                    <Action name='ImportBook' 
                            caption='Добавить книгу...' 
                            hint='' 
                            shortcut='' 
                            simage='{2}\fbscanner.png' 
                            limage='' 
                            activebars='100' 
                            mmenupath='Библиотека' 
                            position='4:-1:-1' 
                            group='100' 
                            plugin='ImportPlugin' 
                            command='ImportPlugin.Import'/>
                </Actions>
              </Plugin>";

        private ImportOptions settings;

        public ImportPlugin()
        {
            _default_settings = defaultSettings;

            _name = "ImportPlugin";
            _caption = "Book Scanner Plugin";

            //_files_folder = Path.Combine(Path.GetFileName(CommonConsts.cPluginsPath), "ImportFilesFiles");
            _files_folder = Path.Combine("Plugins", "ImportFiles");

            _run_action = RunAction;

            settings = new ImportOptions();
        }

        protected override object CreateCommandList()
        {
            List<PluginCommand> _result = new List<PluginCommand>();

            _result.Add(new PluginCommand("ImportPlugin.Import", "Добавить книгу"));

            return CommonParams.AddParam("CommandList", _result, null);
        }

        public override object RunAction(object aParams)
        {
            string action = CommonParams.GetParam(CommonConsts.cParamAction, aParams, String.Empty, 1);
            string objectName = GetObjectFromCommand(action);
            action = GetActionFromCommand(action);
            string pluginName = CommonParams.GetParam(CommonConsts.cParamPlugin, aParams, String.Empty, 1);

            if (pluginName == String.Empty || pluginName == "ImportPlugin")
            {
                aParams = CommonParams.AddParam(CommonConsts.cParamCallbackMethod, _run_action, aParams);

                switch (objectName)
                {
                    case "ImportPlugin":
                        switch(action)
                        {
                            case "Import":
                                ImportForm form = new ImportForm(aParams, settings);
                                form.ShowDialog();
                                break;

                        }
                        break;

                    case "CommandList":
                        return CreateCommandList();

                    default:
                        var _result = base.RunAction(aParams);
                        if (_result != null) return _result;
                        break; 
                }
            }
            else
            {
                return _callback(aParams);
            }

            return null;
        }

        protected override void LoadSettings(SettingsConfigElement aSettings)
        {
            base.LoadSettings(aSettings);

            if (aSettings["DontCheckForDuplicate"] == null)
            {
                SettingConfigElement configElement = new SettingConfigElement();
                configElement.Name = "DontCheckForDuplicate";
                configElement.Caption = "Don't check for book duplicate";
                configElement.Value = "False";
            }
            else
            {
                settings.DontCheckForDuplicate = Convert.ToBoolean(aSettings["DontCheckForDuplicate"].Value);
            }
        }
    }
}
