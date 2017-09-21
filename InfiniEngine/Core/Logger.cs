using System;

namespace InfiniEngine {

    public delegate void OnLogUpdate(EventArgs e);

    public static class Logger {

        public static event OnLogUpdate OnUpate;

        private static string logBuffer = "";

        public static void Put(string textToPut) {

            logBuffer += textToPut;

            OnUpate?.Invoke(EventArgs.Empty);

        }

        public static void PutLine(string textToPut) {

            logBuffer += textToPut + "\n";

            OnUpate?.Invoke(EventArgs.Empty);

        }

        public static string GetBuffer() {

            return logBuffer;

        }

        public static void ClearBuffer() {

            logBuffer = "";

            OnUpate?.Invoke(EventArgs.Empty);

        }

    }

}
