using System;
using System.Collections.Generic;
using InfiniEngine.InfiniScript;
using UnityEngine;

namespace InfiniEngine.Managers {

    public class CommandManager {

        private static List<IInfiniCommand> registeredCommands = new List<IInfiniCommand>();
        private static Dictionary<string, EngineVar> registeredVars = new Dictionary<string, EngineVar>();

        public static bool RunCommand(string cmdString) {

            string[] cmdParts = cmdString.Split(' ');
            string cmdName = cmdParts[0];
            string[] cmdArgsPre = new string[cmdParts.Length - 1];
            Array.Copy(cmdParts, 1, cmdArgsPre, 0, cmdParts.Length - 1);
            string[] cmdArgs;

            //Fix strings
            bool found = false;
            int foundIndex = 0;
            List<string> strings = new List<string>();
            for (int p = 0; p < cmdArgsPre.Length; p++) {

                if (cmdArgsPre[p][0] == '"') {

                    found = true;
                    foundIndex = p;

                }

                if (!found) {
                    strings.Add(cmdArgsPre[p]);
                }

                if (found && cmdArgsPre[p][cmdArgsPre[p].Length - 1] == '"') {

                    string allParts = "";
                    for (int a = foundIndex; a <= p; a++) {

                        allParts = allParts + cmdArgsPre[a];
                        if (a < p) allParts = allParts + " ";

                    }

                    allParts = allParts.Remove(0, 1);
                    allParts = allParts.Remove(allParts.Length - 1, 1);
                    strings.Add(allParts);
                    found = false;

                }                

            }

            if (found) {
                Logger.Put("[ERROR] Unterminated string in command!\n");
                return false;
            }

            cmdArgs = strings.ToArray();

            for (int i = 0; i < registeredCommands.Count; i++) {

                IInfiniCommand com = registeredCommands[i];

                if (com.commandName == cmdName) {

                    //It's a match! Move on to run the command and return the results...

                    for (int I = 0; I < cmdArgs.Length; I++) {

                        if (cmdArgs[I][0] == '$') {

                            string varName = cmdArgs[I].TrimStart('$');
                            if (registeredVars.ContainsKey(varName)) {

                                cmdArgs[I] = registeredVars[varName].value;

                            } else {

                                Logger.Put("[ERROR] Invalid var in command!\n");
                                return false;

                            }

                        }

                    }

                    if (com.Execute(cmdArgs)) {

                        return true;

                    } else {

                        Logger.Put("[ERROR] Command execution failed!\n");
                        return false;

                    }

                }

            }

            //Command not found
            Logger.Put("[ERROR] Command not found!\n");
            return false;

        }

        public static void RegisterCommand(IInfiniCommand commandToRegister) {

            registeredCommands.Add(commandToRegister);

        }

        public static void RegisterVar(EngineVar varToRegister) {

            registeredVars.Add(varToRegister.name, varToRegister);

        }

        public static bool DeclareVar(VarType type, string name, string value) {

            switch (type) {

                case VarType.Integer:
                    int newInt;
                    EngineVar newIntVar = new EngineVar();
                    newIntVar.name = name;
                    newIntVar.type = VarType.Integer;
                    if (int.TryParse(value, out newInt)) {
                        newIntVar.value = value;
                        RegisterVar(newIntVar);
                    } else Logger.Put("Invalid var declaration!");
                    return true;

                case VarType.Boolean:
                    bool newBool;
                    EngineVar newBoolVar = new EngineVar();
                    newBoolVar.name = name;
                    newBoolVar.type = VarType.Boolean;
                    if (bool.TryParse(value, out newBool)) {
                        newBoolVar.value = value;
                        RegisterVar(newBoolVar);
                    } else Logger.Put("Invalid var declaration!");
                    return true;

                case VarType.String:
                    EngineVar newStringVar = new EngineVar();
                    newStringVar.name = name;
                    newStringVar.type = VarType.String;
                    newStringVar.value = value;
                    return true;

                default:
                    Logger.Put("Invalid var type!");
                    break;

            }

            return false;
        
        }

        public static EngineVar? GetVar(string varName) {

            if (registeredVars.ContainsKey(varName)) {

                return registeredVars[varName];

            }

            Logger.Put("[ERROR] Variable \"" + varName +"\" not found!\n");

            return null;

        }

    }

}
