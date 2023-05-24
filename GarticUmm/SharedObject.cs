using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedObject
{
    class Constant
    {
        public static readonly IPAddress LOCALHOST = IPAddress.Parse("127.0.0.1");
        // public static readonly IPAddress LOCALHOST = IPAddress.Parse("192.168.182.194");
        public static readonly int PORT = 43673;
        public static readonly Encoding UTF8 = Encoding.GetEncoding("UTF-8");
    }

    class ResClass
    {
        /**
         * Event code list
         * 
         * [Base code]
         * 1000: Success
         * 1001: Critical Error
         * 
         * [Server code]
         * 2000: Server created
         * 2001: Server stoped
         * 
         * [Client code]
         * 3000: Client connected
         * 3001: Client disconnected
         * 
         * [Chat code]
         * 
         * [Image code]
         * 
         */
        private int code;
        private string message;

        public ResClass()
        {
            this.code = 0;
            this.message = "";
        }

        public ResClass(int code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public ResClass Res
        {
            get { return this; }
        }

        public int Code
        {
            get { return code; }
        }

        public string Message
        {
            get { return message; }
        }
    }
}
