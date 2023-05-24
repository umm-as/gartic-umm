using System.Collections.Generic;
using System.Drawing;

namespace GarticUmm
{
    enum MyColor
    {
        red, yellow, green, blue, purple, black, white
    }
    enum MyThick
    {
        small, medium, large
    }

    internal class DrawLineHistroy
    {
        private List<MyLine> history;

        public DrawLineHistroy()
        {
            history = new List<MyLine>();
        }

        public void loadHistory(List<MyLine> history)
        {
            this.history = history;
        }

        public List<MyLine> getHistory()
        {
            return history;
        }

        public void addHistory(Pen pen, Point pointFrom, Point pointDest)
        {
            int fromX = pointFrom.X;
            int fromY = pointFrom.Y;
            int destX = pointDest.X;
            int destY = pointDest.Y;
            MyColor color = MyLine.color2MyColor(pen.Color);
            MyThick thick = MyLine.width2MyThick(pen.Width);

            history.Add(new MyLine(fromX, fromY, destX, destY, color, thick));
        }

        public void clearHistory()
        {
            history.Clear();
        }

        public string toCSVString()
        {
            string csvString = "";
            foreach (var item in history)
            {
                csvString += item.toSCVString();
            }

            return csvString;
        }

        public static List<MyLine> toList(string csvString)
        {
            List<MyLine> result = new List<MyLine>();

            var lines = csvString.Split(';');
            foreach (var line in lines)
            {
                string[] item = line.Split(',');
                if (line.Length < 6) break;

                int fromX = int.Parse(item[0]);
                int fromY = int.Parse(item[1]);
                int destX = int.Parse(item[2]);
                int destY = int.Parse(item[3]);
                MyColor color = MyLine.string2MyColor(item[4]);
                MyThick thick = MyLine.string2MyThick(item[5]);

                result.Add(new MyLine(fromX, fromY, destX, destY, color, thick));
            }

            return result;
        }
    }

    class MyLine
    {
        private int fromX;
        private int fromY;
        private int destX;
        private int destY;
        private MyColor color;
        private MyThick thick;

        public MyLine(int fromX, int fromY, int destX, int destY, MyColor color, MyThick thick)
        {
            this.fromX = fromX;
            this.fromY = fromY;
            this.destX = destX;
            this.destY = destY;
            this.color = color;
            this.thick = thick;
        }

        public int FromX
        {
            get { return fromX; }
        }
        public int FromY
        {
            get { return fromY; }
        }
        public int DestX
        {
            get { return destX; }
        }
        public int DestY
        {
            get { return destY; }
        }

        public string toSCVString()
        {
            string csvString = "";
            csvString += fromX.ToString() + ',';
            csvString += fromY.ToString() + ',';
            csvString += destX.ToString() + ',';
            csvString += destY.ToString() + ',';
            csvString += color.ToString() + ',';
            csvString += thick.ToString() + ';';

            return csvString;
        }

        public Color getColor()
        {
            return myColor2Color(color);
        }

        public float getWidth()
        {
            return myThick2Width(thick);
        }

        public static MyColor color2MyColor(Color color)
        {
            switch (color.Name)
            {
                case "Black":
                    return MyColor.black;
                case "Red":
                    return MyColor.red;
                case "Yellow":
                    return MyColor.yellow;
                case "Green":
                    return MyColor.green;
                case "Blue":
                    return MyColor.blue;
                case "Purple":
                    return MyColor.purple;
                case "White":
                    return MyColor.white;
                default:
                    return MyColor.black;
            }
        }

        public static Color myColor2Color(MyColor color)
        {
            switch (color)
            {
                case MyColor.black:
                    return Color.Black;
                case MyColor.red:
                    return Color.Red;
                case MyColor.yellow:
                    return Color.Yellow;
                case MyColor.green:
                    return Color.Green;
                case MyColor.blue:
                    return Color.Blue;
                case MyColor.purple:
                    return Color.Purple;
                case MyColor.white:
                    return Color.White;
                default:
                    return Color.Black;
            }
        }

        public static MyThick width2MyThick(float width)
        {
            switch (width)
            {
                case 5:
                    return MyThick.small;
                case 10:
                    return MyThick.medium;
                case 30:
                    return MyThick.large;
                default:
                    return MyThick.small;
            }
        }

        public static float myThick2Width(MyThick thick)
        {
            switch (thick)
            {
                case MyThick.small:
                    return 5;
                case MyThick.medium:
                    return 10;
                case MyThick.large:
                    return 30;
                default:
                    return 5;
            }
        }

        public static MyColor string2MyColor(string color)
        {
            switch (color)
            {
                case "black":
                    return MyColor.black;
                case "red":
                    return MyColor.red;
                case "yellow":
                    return MyColor.yellow;
                case "green":
                    return MyColor.green;
                case "blue":
                    return MyColor.blue;
                case "purple":
                    return MyColor.purple;
                case "white":
                    return MyColor.white;
                default:
                    return MyColor.black;
            }
        }

        public static MyThick string2MyThick(string thick)
        {
            switch (thick)
            {
                case "small":
                    return MyThick.small;
                case "medium":
                    return MyThick.medium;
                case "large":
                    return MyThick.large;
                default:
                    return MyThick.small;
            }
        }
    }
}
