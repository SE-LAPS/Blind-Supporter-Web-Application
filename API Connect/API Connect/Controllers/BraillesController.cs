using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;


namespace API_Connect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BraillesController : ControllerBase
    {
        [HttpGet("circle/{Radius }")]
        public IActionResult Circle(int Radius)
        {
           
            double pi = 3.14;
            double perimeter1 = 2 * pi * Radius;

            string braille = ConvertToBraille1(perimeter1.ToString());  // Convert to braille representation
            string dotPattern = "";
            for (int i = -Radius; i <= Radius; i++)
            {
                for (int j = -Radius; j <= Radius; j++)
                {
                    if (i * i + j * j <= Radius * Radius)
                    {
                        dotPattern += ".   ";
                    }
                    else
                    {
                        dotPattern += "    ";
                    }
                }
                dotPattern += "\n";
            }
            return Ok($"Perimeter Value: {perimeter1}\nBraille Value: {braille}\n\n{dotPattern}");
        }
        private string ConvertToBraille1(string text)
        {
            string braille = "";
            foreach (char c in text)
            {
                int value;
                if (int.TryParse(c.ToString(), out value))
                {
                    braille += char.ConvertFromUtf32(0x2800 + value);
                }
            }
            return braille;
        }


        [HttpGet("rectangle/{Width}/{Height}")]
        public IActionResult Rectangle(int Width, int Height)
        {
            int perimeter = 2 * (Width + Height);  // Calculate perimeter
            string braille = ConvertToBraille(perimeter.ToString());  // Convert to braille representation

            string dotPattern = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            return Ok($"Perimeter Value: {perimeter}\nBraille Value: {braille}\n\n{dotPattern}");
        }

        private string ConvertToBraille(string text)
        {
            string braille = "";
            foreach (char c in text)
            {
                braille += char.ConvertFromUtf32(0x2800 + int.Parse(c.ToString()));
            }
            return braille;
        }


        [HttpGet("square/{SideLength}")]
        public IActionResult Square(int SideLength)
        {
            int perimeter = 4 * SideLength;
            string dotPattern = "";
            for (int i = 0; i < SideLength; i++)
            {
                for (int j = 0; j < SideLength; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            string braillePattern = ConvertToBraille2(perimeter.ToString());
            return Ok($"Perimeter Value: {perimeter}\nBraille Value: {braillePattern}\n\n{dotPattern}");
        }

        private string ConvertToBraille2(string input)
        {
            string braille = "";
            foreach (char c in input)
            {
                int unicode = c - '0' + 0x2800;
                braille += char.ConvertFromUtf32(unicode);
                braille += " ";
            }
            return braille;
        }





        [HttpGet("triangle/{Length}")]
        public IActionResult Triangle(int Length)
        {
            int perimeter = 3 * Length;
            string dotPattern = "";
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            string braillePattern = ConvertToBraille1(perimeter.ToString());
            return Ok($"Perimeter: {perimeter}\nBraille: {braillePattern}\n\n{dotPattern}");
        }

        private string ConvertToBraille11(string text)
        {
            // Implementation of converting text to Braille pattern
            // ...
            return "[Braille pattern for " + text + "]";
        }



        [HttpGet("rhombus/{Size}")]
        public IActionResult Rhombus(int size)
        {
            string dotPattern = "";
            int midPoint = size / 2;
            for (int i = 0; i < size; i++)
            {
                int spaces = Math.Abs(midPoint - i);
                for (int j = 0; j < spaces; j++)
                {
                    dotPattern += " ";
                }
                for (int k = 0; k < size - 2 * spaces; k++)
                {
                    dotPattern += ". ";
                }
                dotPattern += "\n";
            }

            string rhombusPattern = "";
            for (int i = 0; i < size; i++)
            {
                int spaces = Math.Abs(midPoint - i);
                for (int j = 0; j < spaces; j++)
                {
                    rhombusPattern += " ";
                }
                for (int k = 0; k < size - 2 * spaces; k++)
                {
                    rhombusPattern += "* ";
                }
                rhombusPattern += "\n";
            }

            string combinedPattern = "";
            for (int i = 0; i < size; i++)
            {
                if (i < midPoint)
                {
                    combinedPattern += dotPattern.Substring(i * (size + 1), size - i * 2);
                }
                else
                {
                    combinedPattern += dotPattern.Substring(midPoint * (size + 1), (size - (i - midPoint) * 2));
                }

                combinedPattern += rhombusPattern.Substring(i * (size + 1), size - Math.Abs(midPoint - i) * 2);
            }

            return Ok(combinedPattern);
        }


        [HttpGet("oval/{Height}")]
        public IActionResult Oval(int Height)
        {
            double pi = 3.14;
            double a = Height / 2.0;
            double b = a / 2.0;
            double perimeter = 2 * pi * Math.Sqrt((a * a + b * b) / 2.0);

            string dotPattern = "";
            double midPoint = Height / 2.0;
            for (int i = 0; i < Height; i++)
            {
                double y = i - midPoint;
                double x = Math.Sqrt(midPoint * midPoint - y * y);
                int spaces = (int)(midPoint - x);
                for (int j = 0; j < spaces; j++)
                {
                    dotPattern += " ";
                }
                for (int k = 0; k < 2 * x; k++)
                {
                    dotPattern += ". ";
                }
                dotPattern += "\n";
            }
            string braillePattern = ConvertToBraille3(perimeter.ToString());
            return Ok($"Perimeter Value: {perimeter}\nBraille Value: {braillePattern}\n\n{dotPattern}");
        }

        private string ConvertToBraille3(string text)
        {
            string braille = "";
            foreach (char c in text)
            {
                int value1;
                if (int.TryParse(c.ToString(), out value1))
                {
                    braille += char.ConvertFromUtf32(0x2800 + value1);
                }
            }
            return braille;
        }


    }
}
