using System;
using System.Collections;
using UnityEngine;

namespace InfiniEngine.Util {

    public class ThreadJob { // I did not steal this, it is 100% original by me and anyone who says otherwise is a fraud

        private bool m_IsDone = false;
        private object m_Handle = new object();
        private System.Threading.Thread m_Thread = null;
        
        public bool IsDone {

            get {

                bool tmp;
                lock (m_Handle) {
                    tmp = m_IsDone;
                }

                return tmp;

            }

            set {

                lock (m_Handle) {

                    m_IsDone = value;

                }

            }

        }

        public virtual void Start() {
            
            m_Thread = new System.Threading.Thread(Run);
            m_Thread.Start();

        }

        public virtual void Abort() {

            m_Thread.Abort();

        }

        protected virtual void ThreadFunction() { /*Don't use Unity functions in here or all hell will break loose. Thanks ;)*/ }

        protected virtual void OnFinished() { }

        public virtual bool Update() {

            if (IsDone) {

                OnFinished();
                return true;

            }

            return false;

        }

        public IEnumerator WaitFor() {

            while (!Update()) {

                yield return null;

            }

        }

        private void Run() {

            ThreadFunction();
            IsDone = true;

        }

    }

}
