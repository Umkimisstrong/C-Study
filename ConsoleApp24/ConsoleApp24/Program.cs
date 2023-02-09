/*Random random = new Random();
int randomInt = random.Next(3);
Console.WriteLine(randomInt);
string s = randomInt.ToString();*/
/*
switch (s)
{
    case "1":
        s = "2";
        break;
    case "2":
        s = "3";
        break;
    case "3":
        s = "4";
        break;


}
*/

string user = string.Empty;
int userInt = 0;
do
{
    Console.WriteLine("가위바위보 게임 시작 : 가위(1), 바위(2), 보(3) 를 입력하세요");
    Console.WriteLine("▼");

    user = Console.ReadLine();
}
while (!string.IsNullOrEmpty(user) && int.TryParse(user, out userInt) && userInt != 1 && userInt != 2 && userInt != 3);



Random random = new Random();
int randomInt = random.Next(1, 4);
string computer = "";
switch (randomInt)
{
    case 1:
        computer = "가위";
        break;
    case 2:
    computer = "바위";
        break;
    case 3:
        computer = "보";
        break;
}switch (userInt)
{
    case 1:
        user = "가위";
        break;
    case 2:
        user = "바위";
        break;
    case 3:
        user = "보";
        break;
}


if (randomInt == userInt)
{
    Console.Write(string.Format("무승부 - 컴퓨터 : {0}, 유저 : {1}", computer, user));
}
else
{ 

}


