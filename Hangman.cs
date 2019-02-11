using System;

class MainClass {

/*
The fillblanks function will,
if called, fill the blanks for
the user if they guess a letter
correctly.
*/
static string fillblanks(string word, string letter, string blanks){
  /*
  We use a "for" loop to check each
  letter of the word and compare to
  the user's guess.
  */
  for(int i = 0; i<word.Length; i++){

    /*
    In this loop, each letter is compared
    to the letter the user has guessed. If
    the letter matches, the _ (blank) at the
    same index will be replaced.

    (for example, the blank for "word" will be
    ____ and if "o" is guessed, it becomes _o__.)
    */
    if ( word[i].ToString() == letter ){

      char[] ch = blanks.ToCharArray();

      /*
      So, here we convert the letter to a
      char type and set "blanks" equal to
      itself with the letter in place.
      */
      ch[i] = Convert.ToChar(letter);
      blanks = new string (ch);
    
    }

  }

  //Here, we return the new set of blanks.
  return blanks;
 }

static void Main () {
   //This variable stores the letters that the user has guessed.
  string used = "";

  //This variable represents the word that the user is guessing.
  Console.Write("Word: ");
  string word = Console.ReadLine().ToLower();

  //This variable represents the set of blanks that represent the word.
  string blanks = new String('_', word.Length);

  //This variable represents the amount of tries the user has.
  int tries = 6;

  //This makes sure that everything is lowercase.
  word = word.ToLower();

  Console.Clear();
  
  /*
  In our main loop, we make sure that
  the word hasn't been guessed, and
  the user hasn't run out of tries.
  If they have, the loop closes and tells
  the user if they have won or lost.
  */
  
  while (blanks.Contains("_") && (tries > 0)){

    //Here we output game info to the user.
    Console.WriteLine(blanks + "\n");
    Console.WriteLine("Tries left: " + tries + "\n");
    Console.WriteLine("Letters used: " + used + "\n");

    //Here we ask the user for the letter they will guess with.
    //We also make sure that the input is lowercase.
    Console.Write("Letter: ");
    string guess = Console.ReadLine().ToLower();
	
	Console.Clear();

    /*
    If the "used" variable (where we store used characters)
    contains the letter guessed, this means the letter has
    already been used. This means that we need NOT
    deduct tries from the user for accidentally re-using a
    guess. Here, we check if the user has used their guess
    previously, and notify them accordingly.
    */
    if (used.Contains(guess)){

      Console.WriteLine("You already used " + guess + "!\n");

    /*
    Here we check if the user's guess is a single letter
    and react accordingly.
    */
    }else if (guess.Length > 1){

      Console.WriteLine("Your guess must be one character!\n");

    }else{

      /*
      Here, we check if the word has the letter guessed
      by the user. If it does, the letter is passed through the "fillblanks"
      function and displayed in "blanks". If not, they lose a try.
      */
      if (word.Contains(guess)){

        blanks = fillblanks(word,guess,blanks);

      }else{

        tries--;

      }

      //Here, we store the user's guess to make sure they don't re-use it.
      used += (guess + " ");

    }
	
  }

 //Here, the loop has closed and we must make sure the word has been guessed or not.
 //If blanks has an _, the word has not been guessed and the user has lost.
 //If blanks has no _'s, the word has been guessed and the user wins.
 if ( blanks.Contains("_") ){

   Console.Write("The answer was " + word + "!\n");
   Console.WriteLine("YOU LOSE ! ! !\n");

 }else{

   Console.WriteLine(word + "!\n\n");
   Console.WriteLine("YOU WIN ! ! !\n");

 }
 
 Console.Read();

}

}





