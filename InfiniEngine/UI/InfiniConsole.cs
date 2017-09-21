using System;
using UnityEngine;
using InfiniEngine.Managers;

namespace InfiniEngine.UI {

    public class InfiniConsole {

        private const string consoleVersion = "InfiniEngine Console Pre-Alpha 1 ©2017 Neptunium Studios";
        private Window consoleWindow;
        private string consoleCommand = "";
        private TextArea consoleText;

        public InfiniConsole() {

            consoleWindow = new Window(InterfaceManager.GetFreeWindowID(), new Rect(10, 10, Screen.width / 2, Screen.height - 20), "Console");
            InterfaceManager.AddWindow(consoleWindow);

            TextArea consoleTextArea = new TextArea(new Rect(20, 30, consoleWindow.windowRegion.width - 40, consoleWindow.windowRegion.height - 90), Logger.GetBuffer());
            consoleText = consoleTextArea;
            consoleWindow.AddControl(consoleTextArea);

            TextField consoleTextField = new TextField(new Rect(20, consoleWindow.windowRegion.height - 50, consoleWindow.windowRegion.width - 40, 30), consoleCommand);
            consoleTextField.AddKeytrap(KeyCode.Return);
            consoleTextField.OnTrapkeyPressed += new OnTextFieldTrapkeyPressed(consoleTextField_OnTrapkeyPressed);
            consoleWindow.AddControl(consoleTextField);

            Logger.OnUpate += new OnLogUpdate(Logger_OnUpate);

        }

        void Logger_OnUpate(EventArgs e) {

            consoleText.textAreaCaption = Logger.GetBuffer();

        }

        void consoleTextField_OnTrapkeyPressed(object sender, TrapkeyEventArgs e) {

            if (e.trappedKey != KeyCode.Return) return;

            TextField tf = (TextField)sender;
            consoleCommand = tf.textFieldCaption;
            if (consoleCommand[0] == '$') {

                string varName = consoleCommand.TrimStart('$');
                if (CommandManager.GetVar(varName) != null) {

                    if (CommandManager.GetVar(varName).Value.type == InfiniScript.VarType.String) {

                        Logger.PutLine("\"" + CommandManager.GetVar(varName).Value.value + "\"");

                    } else {

                        Logger.PutLine(CommandManager.GetVar(varName).Value.value);

                    }

                }

                tf.textFieldCaption = "";
                return;
            
            }
            if (consoleCommand.ToLower() == "ver") { Logger.PutLine(consoleVersion); tf.textFieldCaption = ""; return; }
            CommandManager.RunCommand(consoleCommand);
            tf.textFieldCaption = "";

        }

    }

}
