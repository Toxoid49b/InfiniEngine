using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfiniEngine {

    public delegate void OnLogUpdate(EventArgs e);

    public static class Logger {

        public static event OnLogUpdate OnUpate;

        private static string logBuffer = "";

        public static void Put(string textToPut) {

            logBuffer += textToPut;

            if (OnUpate != null) OnUpate(EventArgs.Empty);

        }

        public static void PutLine(string textToPut) {

            logBuffer += textToPut + "\n";

            if (OnUpate != null) OnUpate(EventArgs.Empty);

        }

        public static string GetBuffer() {

            return logBuffer;

        }

        public static void ClearBuffer() {

            logBuffer = "";

            if (OnUpate != null) OnUpate(EventArgs.Empty);

        }

    }

}
