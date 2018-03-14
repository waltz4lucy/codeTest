using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodeTest
{
    public class Superb
    {
        public Superb()
        {
            /*
                다음은 구현하실 기능의 명세서 입니다.
                명세서에 기재된 대로 기능을 완성해주세요.
                GetMaxAlphaNumeric 메서드(C#)

                string 안에 포함된 개수가 가장 많은 알파벳 혹은 숫자를 골라냅니다.

                구문
                public static char GetMaxAlphaNumeric(string content)

                매개 변수
                content
                Type: System.String
                검사 할 문자열입니다.

                반환 값
                Type: System.Char
                인자로 넘겨받은 content 문자열 중 가장 많이 들어있는 알파벳 혹은 숫자를 리턴 합니다.

                문자의 수가 동일하다면 ASCII 코드 상으로 더 높은 값을 가진 문자를 리턴 합니다.

                반환 할 문자가 없을 경우 ASCII NUL 문자를 리턴 합니다.

                예외
                ArgumentNullException
                content 가 null 일 경우 발생되어야 하는 예외입니다.

                기대 결과
                GetMaxAlphaNumeric(“foo”) == ‘o’
                GetMaxAlphaNumeric(“bbccaa”) == ‘c’
                GetMaxAlphaNumeric(“ab2c2d”) == ‘2’
                GetMaxAlphaNumeric(“abCD”) == ‘b’
                GetMaxAlphaNumeric(“#a## # #”) == ‘a’
                GetMaxAlphaNumeric(“@#*@@#*”) == ‘\0’
                GetMaxAlphaNumeric(“”) == ‘\0’
                GetMaxAlphaNumeric(null) == ArgumentNullException

                제한 사항
                C# 언어의 로직을 어떻게 작성 하는지,
                제어문(조건문, 반복문, 기타 등등)을 어떻게 다루는지,
                코딩 스타일 등등을 확인하기 위한 테스트 입니다.

                따라서 기본 제공되는 System.Char.IsLetterOrDigit 등의 유틸리티 함수를 사용하지 않고 직접 비교 연산을 사용해주세요.
            */

            try
            {
                Assert.AreEqual(GetMaxAlphaNumeric("foo"), 'o');
                Assert.AreEqual(GetMaxAlphaNumeric("bbccaa"), 'c');
                Assert.AreEqual(GetMaxAlphaNumeric("ab2c2d"), '2');
                Assert.AreEqual(GetMaxAlphaNumeric("abCD"), 'b');
                Assert.AreEqual(GetMaxAlphaNumeric("#a## # #"), 'a');
                Assert.AreEqual(GetMaxAlphaNumeric("@#*@@#*"), '\0');
                Assert.AreEqual(GetMaxAlphaNumeric(""), '\0');
                GetMaxAlphaNumeric(null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("content", ex.ParamName);
            }
        }

        public static char GetMaxAlphaNumeric(string content)
        {
            if (null == content)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < content.Length; i++)
            {
                char key = content[i];
                if (!IsLetterOrDigit(key))
                {
                    continue;
                }
                else if (dic.ContainsKey(key))
                {
                    dic[key]++;
                }
                else
                {
                    dic.Add(key, 1);
                }
            }

            int maxCnt = 0;
            foreach(KeyValuePair<char, int> kv in dic)
            {
                if (kv.Value >= maxCnt)
                {
                    maxCnt = kv.Value;
                }
            }

            char maxChar = char.MinValue;
            foreach (KeyValuePair<char, int> kv in dic)
            {
                if (kv.Value == maxCnt && kv.Key > maxChar)
                {
                    maxChar = kv.Key;
                }
            }

            return maxChar;
        }

        public static bool IsLetterOrDigit(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
        }
    }
}
