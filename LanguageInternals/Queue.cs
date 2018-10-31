using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInternals
{
    public class Queue
    {
        private Stack<int> _stack1;
        private Stack<int> _stack2;

        public Queue()
        {
            this._stack1 = new Stack<int>();
            this._stack2 = new Stack<int>();
        }

        public void Enqueue(int value)
        {
            _stack1.Push(value);
        }

        public int Dequeue()
        {
            int returnVal;
            bool lastValPopped = false;
            
            while (!lastValPopped)
            {
                if (this._stack1.Count == 0)
                {
                    lastValPopped = true;
                }
                else
                {
                    this._stack2.Push(this._stack1.Pop());
                }
            }

            returnVal = this._stack2.Pop();
            lastValPopped = false;

            while (!lastValPopped)
            {
                if (this._stack2.Count == 0)
                {
                    lastValPopped = true;
                }
                else
                {
                    this._stack1.Push(this._stack2.Pop());
                }
            }

            return returnVal;
        }
    }
}
