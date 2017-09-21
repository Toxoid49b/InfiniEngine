using System;

namespace InfiniEngine.InfiniScript {

    public interface IInfiniCommand {

        string commandName {get; set;}
        bool Execute(string[] cmdArgs);

    }

}
