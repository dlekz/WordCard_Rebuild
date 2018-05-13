using System;

namespace logic
{
    public class WordTable
    {
        public bool PrintFlag { get; set; }
        public int Id { private set; get; }
        public string Word { private set; get; }
        public string Translate { private set; get; }
        public string ImgPath {private set; get;}
        public int Status { get; set; }

        public WordTable(int id, string word, string translate, string img, int status) { 
            Id = id;
            Word = word;
            Translate = translate;
            ImgPath = img;
            PrintFlag = false;
            Status = status;
        }
    }
}