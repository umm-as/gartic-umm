using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedObject
{
    class Constant
    {
        public static readonly IPAddress LOCALHOST = IPAddress.Parse("127.0.0.1");
        //public static readonly IPAddress LOCALHOST = IPAddress.Parse("192.168.182.194");
        public static readonly int PORT = 43673;
        public static readonly Encoding UTF8 = Encoding.GetEncoding("UTF-8");

        // Event state
        public static readonly string GAME_START = "GAME_START";
        public static readonly string END_PRESENT_STAGE = "END_PRESENT_STAGE";
        public static readonly string START_DRAW_OWN_IMAGE_STAGE = "START_DRAW_OWN_IMAGE_STAGE";
        public static readonly string END_DRAW_OWN_IMAGE_STAGE = "END_DRAW_OWN_IMAGE_STAGE";
        public static readonly string END_DRAW_IMAGE_STAGE = "END_DRAW_IMAGE_STAGE";
        public static readonly string END_CHECK_IMAGE_STAGE = "END_CHECK_IMAGE_STAGE";

        // Error state
        public static readonly string ERROR_ALREADY_GAME_IS_RUNNING = "ERROR_ALREADY_GAME_IS_RUNNING";
        public static readonly string ERROR_NOT_ENOUGH_PLAYER = "ERROR_NOT_ENOUGH_PLAYER";
        public static readonly string ERROR_PLAYER_LEFT_WHILE_GAME_IS_RUNNING = "ERROR_PLAYER_LEFT_WHILE_GAME_IS_RUNNING";

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

        public static ResClass Parse(string res)
        {
            string pattern = "\\d+";
            Regex reg = new Regex(pattern);

            string temp = res.Substring(0, res.IndexOf(','));
            string code = reg.Match(temp).Value;
            string strData = res.Substring(res.IndexOf(',') + 1).Trim();

            return new ResClass(int.Parse(code), strData);
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
