CSharpEx
=========

C# 개발 Tip
---
1. TryGetValue() 사용으로 경쟁상태(race condition) 회피
    ```
    var d1 = new Dictionary<string,int>();
    //.. 
    if(d1.ContainsKey("Key")){
        //다른 쓰레드에서 해당 아이템 제거시 문제 발생.
    }

    //값을 체크 dictionary내에 값이 있으면 Out parameter
    Int32 result = new Int32();    
    if(d1.TryGetValue("Key",out result)){
    }else{
        //Key 없음..
    }
    ```
2. Switch 문에 pattern matching 사용 : C# 7 Case Pattern 추가 switch문 core types 제한 없음

    Card<-Robot<-Cyborg
    ```
    var cards = CardSource.GetCards();
    foreach(var vard in cards)
    {
        switch(card)
        {
            case Robot my
        }
    }
    ```

C# Performance Tip 
---------
1. Loop 내 Array Lenth
   ```
   string[] names = { "Akshay", "Patel", "Panth" };
   for (int i = 0; i < names.Length; i++)
   {}
   //0.191 msec
   string[] names1 = { "Akshay", "Patel", "Panth" };
   int k = names1.Length;
   for (int j = 0; j < k; j++)
   {}
   //0.0364 msec
   ```

2. List Count vs Count()
    ```
    Stopwatch watch = new Stopwatch();
    watch.Start();
    int count1 = strs.Count;
    Console.WriteLine("Count  -{0}", watch.Elapsed.TotalMilliseconds);//Count  -0.0253

    watch.Restart();
    int count = strs.Count();
    Console.WriteLine("Count()-{0}", watch.Elapsed.TotalMilliseconds);//Count() - 0.108
    ```

3. List Count() vs Any()
    ```
    watch.Start();
    if (strs.Count() > 0)
    { }
    Console.WriteLine("List.Count()-{0}", watch.Elapsed.TotalMilliseconds);//List.Count()-0.1727

    watch.Restart();
    if (strs.Any())
    { } 
    Console.WriteLine("List.Any() - {0}", watch.Elapsed.TotalMilliseconds);//List.Any() - 0.0991
    ```

4. String Add - Interpolation vs Format vs Concat vs Stringbuilder.Append.  
속도 측면에서 문자열 보간이 가장 느림  
**stringbuilder , Concat < string.Format < String Interpolation 순**
    ```
    s1.Start();
    result = $"{str} {str1} is an author.";
    Console.WriteLine(result);
    Console.WriteLine("String Interpolation " + s1.ElapsedTicks.ToString());
    //String Interpolation 124268
    s1.Restart();
    result = string.Format("{0},{1} is an author.", str, str1);
    Console.WriteLine(result);
    Console.WriteLine("String.Format " + s1.ElapsedTicks.ToString());
    //String.Format 1187
    s1.Restart();
    result = string.Concat(str, str1, "is an auther");
    Console.WriteLine(result);
    Console.WriteLine("String.Concat " + s1.ElapsedTicks.ToString());
    //String.Concat 996
    s1.Restart();
    StringBuilder sb = new StringBuilder();
    sb.Append(str);
    sb.Append(str1);
    sb.Append(" is an auther");
    result = sb.ToString();
    Console.WriteLine(result);
    Console.WriteLine("String Builder " + s1.ElapsedTicks.ToString());
    //String Builder 935
    ```

