using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlExtractor
{
   
    public class Gb2312Encoding : Encoding
    {
        public override string WebName
        {
            get
            {
                return "gb2312";
            }
        }

        public Gb2312Encoding()
        {
            
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            throw new NotImplementedException();
        }

        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            int j = 0;
            char c;
            for (int i = 0; i < byteCount; i += 2)
            {
                if (i + 1 >= bytes.Length)
                {
                    char[] last = Encoding.UTF8.GetChars(new byte[] { bytes[i] });
                    chars[j]=last[0];
                }
                else
                {
                    byte[] bb = new byte[] { bytes[i], bytes[i + 1] };
                    if (Gb2312toUnicodeDictinary.TryGetChar(bb, out c))
                    {
                        chars[j] = c;
                        j++;
                    }
                    else
                    {
                        char[] tt = Encoding.UTF8.GetChars(new byte[] { bb[1] });
                        chars[j] = tt[0];
                        j++;
                        //测试下一个
                        if (i + 2 >= bytes.Length)
                        {
                            char[] tttt = Encoding.UTF8.GetChars(new byte[] { bb[0] });
                            chars[j] = tttt[0];
                            j++;
                        }
                        else
                        {
                            byte[] test = new byte[] { bb[0], bytes[i + 2] };
                            if (Gb2312toUnicodeDictinary.TryGetChar(test, out c))
                            {
                                chars[j] = c;
                                j++;
                                i++;
                            }
                            else
                            {
                                char[] ttt = Encoding.UTF8.GetChars(new byte[] { bb[0] });
                                chars[j] = ttt[0];
                                j++;
                            }

                        }
                    }
                }
            }
           
            return chars.Length;
        }

        public override int GetByteCount(char[] chars, int index, int count)
        {
            return count;
        }
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return count;
        }

        public override int GetMaxByteCount(int charCount)
        {
            return charCount;
        }
        public override int GetMaxCharCount(int byteCount)
        {
            return byteCount;
        }
        public static int CharacterCount
        {
            get { return 7426; }
        }
    }
}
