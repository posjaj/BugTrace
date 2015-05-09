using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class RMBToChinese
{
    ///        获取金额的大写中文文字            返回：中文数字文字
    //        mvarOrDollar 数字金额大小, mstrLanguage 字符串语言 P：简体中文 C：繁体中文  
    /// </summary>
    /// <param name="mvarOrDollar"></param>
    /// <param name="mstrLanguage"></param>
    /// <returns></returns>
    public static string GetDollorStr(double mvarOrDollar)
    {
        //返回简体中文的中文描述
        string result = GetDollorStr(mvarOrDollar, "P");
        int temp = Convert.ToInt32(mvarOrDollar);
        if (temp != mvarOrDollar)
        {
            return result;
        }
        else
        {
            return result + "整";
        }
    }
    public static string GetDollorStr(double mvarOrDollar, string mstrLanguage)
    {
        string t_word;
        string WLAMT;
        //            double tt;
        t_word = "";
        //            If mstrLanguage = "E" Or mstrLanguage = "e" Then
        //                t_word = t_word + noinword(Int(mvarOrDollar))
        //                If mvarOrDollar <> Int(mvarOrDollar) Then
        //                    tt = Int((mvarOrDollar - Int(mvarOrDollar)) * 100)
        //                    t_word = t_word & "And " & " Cents " & noinword(tt)
        //                End If
        //                 
        //            Else
        //            WLAMT = mvarOrDollar.ToString();
        WLAMT = StrFormat(mvarOrDollar, 12, 2);

        for (int i = 0; i < 12; i++)
        {
            if (i != 9)
                t_word = t_word + SHRCHG(WLAMT, WLAMT.Substring(i, 1), i, mstrLanguage);

        }
        string spacestr = "";
        t_word = t_word + spacestr.PadLeft(40 - t_word.Length, ' ');

        //            End If
        return t_word.Trim();
    }

    private static string SHRCHG(string WLAMT, string WLCD, int WLLOC, string mstrLanguage)
    {
        string WLNAME;
        string WLDD;
        if (mstrLanguage == "C")
            WLDD = "货ㄕ珺窾ㄕ珺じ  àだ";
        else
            //WLDD = "亿千百十万千百十元 角分";
            WLDD = "亿仟佰拾万仟佰拾元 角分";

        WLNAME = "    ";
        switch (WLCD)
        {
            case " ":
                WLNAME = "   ";
                break;
            case "1":
                //WLNAME = IIf(mstrLanguage = "C", "滁", "壹") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "滁" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "壹" + WLDD.Substring(WLLOC, 1);
                break;
            case "2":
                //'WLNAME = IIf(mstrLanguage = "C", "禠", "贰") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "禠" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "贰" + WLDD.Substring(WLLOC, 1);

                break;
            case "3":
                //'WLNAME = IIf(mstrLanguage = "C", "把", "叁") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "把" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "叁" + WLDD.Substring(WLLOC, 1);

                break;
            case "4":
                //'WLNAME = IIf(mstrLanguage = "C", "竩", "肆") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "竩" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "肆" + WLDD.Substring(WLLOC, 1);

                break;
            case "5":
                //'WLNAME = IIf(mstrLanguage = "C", "ヮ", "伍") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "ヮ" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "伍" + WLDD.Substring(WLLOC, 1);

                break;
            case "6":
                //'WLNAME = IIf(mstrLanguage = "C", "嘲", "陆") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "嘲" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "陆" + WLDD.Substring(WLLOC, 1);

                break;
            case "7":
                //'WLNAME = IIf(mstrLanguage = "C", "琺", "柒") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "琺" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "柒" + WLDD.Substring(WLLOC, 1);

                break;
            case "8":
                //'WLNAME = IIf(mstrLanguage = "C", "", "捌") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "捌" + WLDD.Substring(WLLOC, 1);
                break;
            case "9":
                //'WLNAME = IIf(mstrLanguage = "C", "╤", "玖") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "╤" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "玖" + WLDD.Substring(WLLOC, 1);
                break;
            case "0":
                string locList = "123567";
                if (locList.IndexOf(WLLOC.ToString().Trim()) > 0 && WLAMT.Substring(WLLOC + 1, 1) != "0")
                    if (mstrLanguage.Equals("C"))
                        WLNAME = "箂";
                    else
                        WLNAME = "零";
                else
                    WLNAME = "";
                if (WLAMT.Substring(WLLOC, 1) == ".")
                    WLNAME = WLDD.Substring(WLLOC, 1);

                if (WLLOC == 4 && (WLAMT.Substring(1, 1) != "0" || WLAMT.Substring(2, 1) != "0" || WLAMT.Substring(3, 1) != "0"))
                    if (mstrLanguage.Equals("C"))
                        WLNAME = "窾";
                    else
                        WLNAME = "万";
                break;

        }
        return WLNAME.Trim();
    }

    private static string StrFormat(double Tlong, int Along, int Adec)
    {
        string tstr;


        tstr = Tlong.ToString().Trim();
        if (tstr.IndexOf(".") == -1)
        {
            tstr += ".00";
        }
        else
        {
            if (tstr.IndexOf(".") == 0)
            {
                tstr = "0" + tstr;
            }
            if (tstr.IndexOf(".") == tstr.Length - 1)  //0.  case
            {
                tstr = tstr + "0";
            }
            if (tstr.Substring(tstr.IndexOf(".") + 1).Length == 1)
            {
                tstr = tstr + "0";
            }
            else
            {
                tstr = tstr.Substring(0, tstr.IndexOf(".") + 3);
            }

        }
        if (tstr.Length < 12)
            tstr = tstr.PadLeft(12, ' ');
        return tstr;

    }

    #region 金额由数字转换成大写格式
    /// <summary>
    /// 金额由数字转换成大写格式
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string getChinese(decimal num)
    {
        string str1 = "零壹贰叁肆伍陆柒捌玖"; //0-9所对应的汉字 
        string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
        string str3 = ""; //从原num值中取出的值 
        string str4 = ""; //数字的字符串形式 
        string str5 = ""; //人民币大写金额形式 
        int i; //循环变量 
        int j; //num的值乘以100的字符串长度 
        string ch1 = ""; //数字的汉语读法 
        string ch2 = ""; //数字位的汉字读法 
        int nzero = 0; //用来计算连续的零值是几个 
        int temp; //从原num值中取出的值 
        bool ifFushu = false;//是否负数
        if (num < 0)
        {
            ifFushu = true;
        }
        num = Math.Round(Math.Abs(num), 2); //将num取绝对值并四舍五入取2位小数 
        str4 = ((long)(num * 100)).ToString(); //将num乘100并转换成字符串形式 
        j = str4.Length; //找出最高位 
        if (j > 15) { return "溢出"; }
        str2 = str2.Substring(15 - j); //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

        //循环取出每一位需要转换的值 
        for (i = 0; i < j; i++)
        {
            str3 = str4.Substring(i, 1); //取出需转换的某一位的值 
            temp = Convert.ToInt32(str3); //转换为数字 
            if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
            {
                //当所取位数不为元、万、亿、万亿上的数字时 
                if (str3 == "0")
                {
                    ch1 = "";
                    ch2 = "";
                    nzero = nzero + 1;
                }
                else
                {
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                }
            }
            else
            {
                //该位是万亿，亿，万，元位等关键位 
                if (str3 != "0" && nzero != 0)
                {
                    ch1 = "零" + str1.Substring(temp * 1, 1);
                    ch2 = str2.Substring(i, 1);
                    nzero = 0;
                }
                else
                {
                    if (str3 != "0" && nzero == 0)
                    {
                        ch1 = str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 == "0" && nzero >= 3)
                        {
                            ch1 = "";
                            ch2 = "";
                            nzero = nzero + 1;
                        }
                        else
                        {
                            if (j >= 11)
                            {
                                ch1 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                ch1 = "";
                                ch2 = str2.Substring(i, 1);
                                nzero = nzero + 1;
                            }
                        }
                    }
                }
            }
            if (i == (j - 11) || i == (j - 3))
            {
                //如果该位是亿位或元位，则必须写上 
                ch2 = str2.Substring(i, 1);
            }
            str5 = str5 + ch1 + ch2;

            if (i == j - 1 && str3 == "0")
            {
                //最后一位（分）为0时，加上“整” 
                str5 = str5 + '整';
            }
        }
        if (num == 0)
        {
            str5 = "零元整";
        }
        if (ifFushu)
        {
            str5 = "负" + str5;
        }
        return str5;
    }
    #endregion
}

