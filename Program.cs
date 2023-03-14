using System;
using System.Collections.Generic;

namespace TicTacToe
{
  public class yikyakyoe
  {
    public static void Main()
    {
      
      //add decision for single or multiplayer after singleplayer finished
      
      //initialization of variables like turn counter, if the game is over, game board, and win conditions
      int counter;
      bool playerWon;
      bool P2Won; 
      List <string> ticTacToe;
      //lets player choose game type
      gameChoose:
      counter = 0;
      playerWon = false;
      P2Won = false;
      ticTacToe = new List <string> {"| |","| |","| |","| |","| |","| |","| |","| |","| |"};
      Console.WriteLine("1 for singleplayer, 2 for multiplayer");
      string gameChoice = Console.ReadLine();

       void boardPrint()
      {
      Console.WriteLine(ticTacToe[0] + ticTacToe[1] + ticTacToe[2]);
      Console.WriteLine(ticTacToe[3] + ticTacToe[4] + ticTacToe[5]);
      Console.WriteLine(ticTacToe[6] + ticTacToe[7] + ticTacToe[8]);
      }
      //goes to whichever game was chosen
      boardPrint();
      if (gameChoice == "1")
      goto singlePlayer;
      else if (gameChoice == "2")
      goto multiPlayer;
      else
      goto gameChoose;
      //Definition of Win checking method
        void WinCheck()
        {
          //rows
          for(int i = 0; i <= 6; i += 3)
          {
            if(ticTacToe[i] == "|X|" && ticTacToe[i + 1] == "|X|" && ticTacToe[i + 2] == "|X|")
              playerWon = true;
            else if(ticTacToe[i] == "|O|" && ticTacToe[i + 1] == "|O|" && ticTacToe[i + 2] == "|O|")
              P2Won = true;
          }
          //columns
          for(int i = 0; i <= 2; i += 1)
          {
            if(ticTacToe[i] == "|X|" && ticTacToe[i + 3] == "|X|" && ticTacToe[i + 6] == "|X|")
              playerWon = true;
            else if(ticTacToe[i] == "|O|" && ticTacToe[i + 3] == "|O|" && ticTacToe[i + 6] == "|O|")
              P2Won = true;
          }
          //diagonals
          if(ticTacToe[0] == "|X|" && ticTacToe[4] == "|X|" && ticTacToe[8] == "|X|")
          playerWon = true;
          else if(ticTacToe[0] == "|O|" && ticTacToe[4] == "|O|" && ticTacToe[8] == "|O|")
          P2Won = true;

          if(ticTacToe[2] == "|X|" && ticTacToe[4] == "|X|" && ticTacToe[6] == "|X|")
          playerWon = true;
          else if(ticTacToe[2] == "|O|" && ticTacToe[4] == "|O|" && ticTacToe[6] == "|O|")
          P2Won = true;
        }
      singlePlayer:
      while(1 == 1)
      {
        //Player turn
        PT:
        Console.WriteLine("Pick a non filled cell from 1 to 9 to place an X");
        //Logic checking for player input
        int playerInput = Convert.ToInt32(Console.ReadLine());
        if(playerInput <= 9 && playerInput >= 1)
          if(ticTacToe[playerInput - 1] != "| |")
          {
            Console.WriteLine("Already filled");
           goto PT;
          }
          else
          {
           ticTacToe[playerInput - 1] = "|X|";
           counter++;
          }
        else
          goto PT;
        
        //methods to set up for next turn
        boardPrint();
        WinCheck();
        //if anybody won or board filled, leave loop
        if (counter >= 9 || playerWon || P2Won)
        break;

        Console.WriteLine("AI goes...");
        P2T:
        //Choosing random number to place O
        Random rnd = new Random(); 
        int P2Choice = rnd.Next(0,9);
        
        if(ticTacToe[P2Choice] != "| |")
           goto P2T;
        else
          {
           ticTacToe[P2Choice] = "|O|";
           counter++;
          }

          //methods to set up for next turn
        boardPrint();
        WinCheck();
        //if anybody won or board filled, leave loop
        if (counter >= 9 || playerWon || P2Won)
        break;
      }

      
      
      //checks who won at the end of it all
      whoWon:
      if(playerWon)
      Console.WriteLine("You won");
      else if (P2Won)
      Console.WriteLine("AI won");
      else
      Console.WriteLine("draw");
      goto gameChoose;

      
      
      multiPlayer:
      while(1 == 1)
      {
        //Player turn
        PT:
        Console.WriteLine("Player 1: Pick a non filled cell from 1 to 9 to place an X");
        //Logic checking for player input
        int playerInput = Convert.ToInt32(Console.ReadLine());
        if(playerInput <= 9 && playerInput >= 1)
          if(ticTacToe[playerInput - 1] != "| |")
          {
            Console.WriteLine("Already filled");
           goto PT;
          }
          else
          {
           ticTacToe[playerInput - 1] = "|X|";
           counter++;
          }
        else
          goto PT;
        
        //methods to set up for next turn
        boardPrint();
        WinCheck();
        //if anybody won or board filled, leave loop
        if (counter >= 9 || playerWon || P2Won)
        break;

        Console.WriteLine("Player 2: Pick a non filled cell from 1 to 9 to place an O");
        P2T:
        //Choosing random number to place O
        int player2Input = Convert.ToInt32(Console.ReadLine());
        if(player2Input <= 9 && player2Input >= 1)
          if(ticTacToe[player2Input - 1] != "| |")
          {
            Console.WriteLine("Already filled");
           goto P2T;
          }
          else
          {
           ticTacToe[player2Input - 1] = "|O|";
           counter++;
          }
        else
          goto P2T;

          //methods to set up for next turn
        boardPrint();
        WinCheck();
        //if anybody won or board filled, leave loop
        if (counter >= 9 || playerWon || P2Won)
        break;
      }
      goto whoWon;
    }
  }
}
