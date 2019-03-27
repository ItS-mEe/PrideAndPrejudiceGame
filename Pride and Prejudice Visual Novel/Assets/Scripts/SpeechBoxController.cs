using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechBoxController : MonoBehaviour
{
    public TextController textController;
    public Text characterBox; 
    public BackgroundImageController backgroundImageController;
    public ChoiceController choiceController;

    
    public GameObject 
    catherinePrefab, elizabethPrefab, 
    georgianaPrefab, janePrefab, 
    lydiaPrefab, msBingleyPrefab, 
    mrBingleyPrefab, mrGardinerPrefab, 
    mrDarcyPrefab, mrsBennetPrefab, 
    wickhamPrefab, mrBennetPrefab;

    public GameObject 
    catherine, elizabeth, 
    georgiana, jane, 
    lydia, msBingley, 
    mrBingley, mrGardiner, 
    mrDarcy, mrsBennet, 
    wickham, mrBennet;


    private IEnumerator script;
    private bool choosing;
    private int choice;

    void Start(){
        script = GetScript();
        Invoke("moveNext", 0.1f);
    }

    private void moveNext(){
        script.MoveNext();
    }
    public void onClick(){
        if(choosing){
            return;
        }

        if(textController.isDoneWithText){
            // advance to next text
            script.MoveNext();
        }
        else{
            textController.expediteText();
        }
    }

    public void makeChoice(int choice){
        choosing = false;
        this.choice = choice;
        this.onClick();
    }

    private IEnumerator GetScript(){
        // Mr Bingley asks Mr Darcy to go with him to the party
      backgroundImageController.location = 1; // TODO: change this
        characterBox.text = "Mr Bingley"; //Smiling
        textController.say("Hey Darcy, want to go to the Tim Cook's social with me? There will be cute girls I swear, and anyways, we are visiting the Apple headquarters in Cupertino anyways.");
        choiceController.offerChoices("I would rather stay in the hotel and read.", "I will go with you, but only to meet new connections.", "Only if you go as my date.");
        choosing = true;
        yield return null;
      
        if(choice == 1){
            //dialogue for choice 1
            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("Reading? You’re so old fashioned. Come on. Please. Please. I’ll be lonely.");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Fine. Whatever.");
            yield return null;

        } else if (choice == 2) {
            //dialogue for choice 2
            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("Yaay!");
            yield return null;

        } else {
            //dialogue for choice 3
            characterBox.text = "Mr. Bingley"; //Confused
            textController.say("What?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Sorry, I have autocorrect in my brain sometimes.");
            yield return null;

            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("So are you coming or not?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Fine. Whatever.");
            yield return null;

        }

        // SOCIAL PARTY #1
        backgroundImageController.location = 1; // TODO: change this
        characterBox.text = "Miss Bingley"; //Smiling
        textController.say("Hey, Mr. Darcy. You made it. How do you like the party?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("It’s ok.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("I know right. Like, there are some people at this party that don’t even deserve to be here, am I right? Like, what is wrong with society right now.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("When I heard about this party I thought only the richest of the rich would come, but now, I’m, like, surrounded by poor peasants.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("Well, yes. Anyways, I have some urgent business with your brother so I  must excuse myself.");
        yield return null;
        //Exit Miss Bingley

        characterBox.text = "Mr. Bingley"; //Grinning
        textController.say("So are you enjoying yourself? Isn’t this party really nice?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("It’s so-so.");
        yield return null;

        //Enter Elizabeth and Jane
        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("Who are these people you have brought with you?");
        yield return null;

        characterBox.text = "Girl #1"; //Smiling
        textController.say("Hi, my name is Jane Bennet. It is a pleasure to meet you.");
        yield return null;

        characterBox.text = "Girl #2"; //Bored
        textController.say("Elizabeth Bennet. Likewise.");
        yield return null;

        characterBox.text = "Darcy Thoughts";//Weird
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Oh no, new people?! YIKES. How do I approach this situation?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Weird
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("*Stiffens* Hello, It is a pleasure to meet you both.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Weird
        textController.say("My name is Fitzwilliam Darcy.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Weird
        textController.say("It is alright to call me Darcy.");
        yield return null;

        characterBox.text = "Jane Bennet"; //Concerned
        textController.say("Are you alright Mr. Darcy? You seem tense.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Weird
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("She is catching on, come on Darcy, think of something, quick!");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Weird
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("*Still stiff* I’m fine, I simply have claustrophobia. This room is a little too small for my taste.");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //laughing
        textController.say("...");
        yield return null;

        characterBox.text = "Jane Bennet"; //Concerned
        textController.say("Alright.");
        yield return null;
        //Chatting continues. Jane and Elizabeth leave.

        characterBox.text = "Mr. Bingley"; //Concerned
        textController.say("Were you alright there Darcy? What happened?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Angry
        textController.say("Never mind that, this party is a lot worse than you implied in our previous exchange.");
        yield return null;

        characterBox.text = "Mr. Bingley"; //Surprised
        textController.say("What are you talking about? There are lots of beautiful women everywhere!");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("What are YOU talking about? There is literally only one woman worth considering at this party, and that is the Miss Jane Bennet you brought over and danced with earlier.");
        yield return null;

        characterBox.text = "Mr. Bingley"; //Normal
        textController.say("Yes she was really pretty... Anyways, I still think you’re delusional buddy. What about her sister Elizabeth? She was nice.");
        yield return null;
        //Show Elizabeth (Normal)

        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("She is passable at best.");
        yield return null;
        //Elizabeth Angry Expression

        //SOCIAL PARTY #2
        //Darcy (Content) sees Elizabeth laughing. Rose filter.
        characterBox.text = "Darcy Thoughts"; //Weird
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Wow, Mr. Bingley was right. Elizabeth is really pretty.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Annoyed
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("...rcy. Hey! Darcy! What’s wrong with you?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("Huh, oh. Sorry, I was distracted.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Annoyed
        textController.say("I’ve noticed you’ve been staring at that Elizabeth girl in all the parties recently. Explain yourself.");
        choiceController.offerChoices("I actually have really started to admire her.", "No, I have not been. I don’t know what you are talking about?", "Her face is like one one of those oddly satisfying gifs. Its, well, oddly satisfying.");
        choosing = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            characterBox.text = "Miss Bingley"; //Annoyed
            textController.say("That sounds like the most rehearsed lie I have ever heard. What is the truth?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("She has this sort of charm to her...");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            characterBox.text = "Miss Bingley"; //Surprised
            textController.say("Is there something wrong with you? Is there something going on in your life right now?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("*Sighs* I was trying to dodge the question. The truth is, she is really quite attractive.");
            yield return null;
        }

        characterBox.text = "Miss Bingley"; //Angry
        textController.say("What! How could you! She is part of the working class.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Angry
        textController.say("She doesn’t, like, even come close to deserving you.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Angry
        textController.say("Her father makes only a measly 500,000 dollars per year while you, like, live in the biggest mansion in Beverly Hills.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("I know, I know. That is why I still have not talked to her. She is not worth my time and effort.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Normal
        textController.say("Good. Now let us continue with the party.");
        yield return null;


        //HOTEL
        //Jane comes in and looks Sick
        characterBox.text = "Darcy Thoughts"; //Surprised
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Wow, she looks horrible. Is that a bicycle outside?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Surprised
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("When Bingley invited you I never imagined you would have come by bicycle, especially considering it is currently raining and you live in Sunnyvale.");
        yield return null;

        characterBox.text = "Jane Bennet"; //Sick
        textController.say("*Coughing* Yes my mother convinced me to come by bike instead of taking an uber.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("You should rest on our beds. You look mortifying.");
        yield return null;

        //Exit Jane
        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("...");
        yield return null;

        //Enter Elizabeth. Rose filter.
        //Darcy Shakes himself himself out of it.
        characterBox.text = "Darcy Thoughts"; //Blushing
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why does she look so good right now? What is wrong with me?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Blushing
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Why are you so flushed? I did not see a taxi pull into the driveway, did you run here?");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Flushed
        textController.say("*Coldly* Actually, yes. And can I see to Jane immediately please?");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Surprised
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why does she still look so pretty.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Surprised
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Wow...");
        yield return null;

        textController.sayFastAdvance("Advances without waiting for player’s input", this.gameObject);
        characterBox.text = "Mr. Darcy"; //Surprised
        textController.say("...I mean yes, yes..of course. Right this way.");
        yield return null;
        //Elizabeth leaves

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("...");
        yield return null;

        //Elizabeth comes back
        characterBox.text = "Elizabeth"; //Worried
        textController.say("Wow she looked horrible.");
        yield return null;

        characterBox.text = "Elizabeth"; //Worried
        textController.say("...");
        yield return null;

        characterBox.text = "Elizabeth"; //Worried
        textController.say("I’m going to stay here for a few days while she recovers.");
        yield return null;

        //DARCY'S ROOM
        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("She stayed for two more days. We spend most of our time reading.");
        yield return null;

        //HOTEL
        characterBox.text = "Miss Bingley"; //Bored
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("I’m tired of all this reading we keep doing! ");
        yield return null;

        characterBox.text = "Miss Bingley"; //Bored
        textController.say("...");
        yield return null;

        characterBox.text = "Miss Bingley"; //Bored
        textController.say("Elizabeth come here and talk me, I would like to get to know you better.");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Annoyed
        textController.say("I was enjoying reading but I will talk with you anyway.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("Isn’t Mr. Darcy really boring. All he does is read books all day. He is almost like a person from the 1800s.");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Grinning
        textController.say("Yes, quite.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I can’t stop thinking about her. What is wrong with me?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("The only the wrong with me is...");
        yield return null;

        //Mr. Bingley comes in
        characterBox.text = "Mr. Bingley"; //Grinning
        textController.say("Guys, stop your cliché conversation. Jane has recovered.");
        yield return null;

        //Jane comes in
        characterBox.text = "Jane Bennet"; //Smiling
        textController.say("Thank you all so much for your hospitality. I really appreciate all of you providing me with your hotel room to recover.");
        yield return null;

        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("It was no problem. I’m so happy I was able to spend time with you~");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Normal
        textController.say("We will be leaving now. Thank you everyone for your hospitality.");
        yield return null;
        //Jane and Elizabeth leave

        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("I really like Jane. I thought she was a really sweet and kind girl. I would love to get to know her more.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("That’s great. We can meet them again another time.");
        yield return null;

        //Scene cut. Fade to black.
        //GYM
        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Alright. My last errand for today is to cancel my gym membership.");
        yield return null;

        //Elizabeth, Jane, and Wickham appear on the screen
        //Rose filter on Elizabeth
        characterBox.text = "Elizabeth Bennet"; //Blushing
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hehehe~");
        yield return null;

        characterBox.text = "Mr. Wickham"; //Smiling
        textController.say("No seriously. You really do.");
        yield return null;
        //DJ record scratching sound effect

        characterBox.text = "Darcy Thoughts"; //Angry
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I despise that Wickham. The things he did … I do not want to remember.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Angry
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I should...");
        choiceController.offerChoices("ignore him and go about my business.", "confront Wickham and take Elizabeth.", "challenge him to a fight like Logan Paul and KSI.");
        choosing = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            characterBox.text = "Darcy Thoughts"; //Angry
            textController.think("Smart idea. I should be brave.");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Awkward
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("...");
            yield return null;

            characterBox.text = "Darcy Thoughts"; //Angry
            characterBox.fontStyle = FontStyle.Italic;
            textController.think("I can not do it, especially in front of Elizabeth.");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            characterBox.text = "Darcy Thoughts"; //Angry
            textController.think("Smart idea. I should be brave.");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Awkward
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("...");
            yield return null;

            characterBox.text = "Darcy Thoughts"; //Angry
            characterBox.fontStyle = FontStyle.Italic;
            textController.think("I can not do it, especially in front of Elizabeth.");
            yield return null;
        }

        characterBox.text = "Mr. Wickham"; //Cold
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("...");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Angry
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I will just finish my errand");
        yield return null;

        //SOCIAL PARTY #3
        characterBox.text = "Darcy Thoughts"; //Normal
        textController.say("I promised myself that I would ask Elizabeth to dance at this party, but I’m having second thoughts…");
        yield return null;
        //Elizabeth comes in
        //Rose filter

        characterBox.text = "Darcy Thoughts"; //Blushing
        textController.think("Should I...");
        choiceController.offerChoices("ask her to dance?", "wait until the next dance?", "teach her about the communist ideals of Karl Marx?");
        choosing = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            characterBox.text = "Mr. Darcy"; //Awkward
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("...");
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            characterBox.text = "Darcy Thoughts"; //Normal
            textController.think("No, no. I will never get another opportunity if I keep doing this.");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Awkward
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("...");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            characterBox.text = "Darcy Thoughts"; //Normal
            textController.think("Wait, what am I thinking? I must have been talking to that Myles too much...");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Awkward
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("*Sigh*");
            yield return null;

            characterBox.text = "Darcy Thoughts"; //Angry
            characterBox.fontStyle = FontStyle.Italic;
            textController.think("I suppose that I have to ask her.");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Awkward
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("...");
            yield return null;
        }

        characterBox.text = "Mr. Darcy"; //Blushing
        textController.say("Hello Miss Elizabeth Bennet.");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Cold
        textController.say("...");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Blushing
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Let’s charm her with my smile.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Blushing
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Can I have the honor of this dance?");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Surprised
        textController.say("...Uh...well..sure...");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Surprised
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("It actually worked?!");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Uh, nice.");
        yield return null;

        //Make Elizabeth bigger
        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("So...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Awkward
        textController.say("...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("..Uh...How was your day?...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Awkward
        textController.say("...Good...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Awkward
        textController.say("...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("...Nice weather recently, eh?...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Awkward
        textController.say("...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("...So...uh...");
        yield return null;

        textController.sayFastAdvance("Advances without waiting for player’s input", this.gameObject);
        characterBox.text = "Elizabeth Bennet"; //Interested
        textController.say("I saw you at the gym.");
        yield return null;
        //Elizabeth gets smaller

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("...Uh...yes");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Interested
        textController.say("I noticed your reaction to my friend Mr. Wickham.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("Uh");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("Nice dancing with you.");
        yield return null;

        textController.sayFastAdvance("Advances without waiting for player’s input", this.gameObject);
        //Elizabeth leaves

        //Mrs. Bennet enters
        characterBox.text = "Mrs. Bennet"; //Cold
        textController.say("*Coldly*  Why hello Mr. Darcy.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Not her again.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hello Mrs. Bennet. How are you this fine evening?");
        yield return null;
        characterBox.text = "Mrs. Bennet"; //Cold
        textController.say("*Coldly* Just fine. Thank you.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why is she so uptight all the time? Was it something I said?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("To what do I owe the pleasure of this conversation to Mrs. Bennet?");
        yield return null;

        characterBox.text = "Mrs. Bennet"; //Happy
        textController.say("I’m sure you have heard already, but my Jane and Mr. Bingley are about to be engaged and I just wanted to tell you, I’m so excited.");
        yield return null;

        characterBox.text = "Mrs. Bennet"; //Happy
        textController.say("I need to plan the wedding already. We’ll need flowers. The best ones are roses because they display love. But there are also lavenders for peace and all that jazz.");
        yield return null;

        characterBox.text = "Mrs. Bennet"; //Happy
        textController.say("Maybe instead we could do chrysanthemums for the fidelity of their marriage....");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Worried
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("What? Things are more serious than I thought...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Worried
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Wait, Mrs. Bennet did you say engaged?");
        yield return null;

        characterBox.text = "Mrs. Bennet"; //Happy
        textController.say("Well, about to be, but yes.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Worried
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I need to stop Bingley from making a mistake.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Excuse me Mrs. Bennet, I must take your leave. I have some business to attend to.");
        yield return null;

        characterBox.text = "Mrs. Bennet"; //AbsentHappy
        textController.say("Yes, yes, go right ahead. *Thinking to herself* The dais will have to be white of course...");
        yield return null;

        //DARCY HOTEL ROOM

        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("Darcy, I’m excited. That woman Jane, she’s amazing. She’s smart, sweet, pretty, kind, and funny. I’m going to ask her to be my wife. What do you think?");
        choiceController.offerChoices("Wait, but I was going to do that.", "That is greatest news I have ever heard come out of your mouth.", "Don’t do it, think about your future.");
        choosing = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            characterBox.text = "Mr. Bingley"; //Surprised
            textController.say("For real?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("No, of course not. It is called sarcasm.");
            yield return null;

            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("What are your actual thoughts?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Speaking from logical standpoint, I think this marriage is completely irrational.");
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            characterBox.text = "Mr. Bingley"; //Surprised
            textController.say("Wait, really, then why are you not smiling?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("No, of course not. It is called sarcasm.");
            yield return null;

            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("What are your actual thoughts?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Speaking from logical standpoint, I think this marriage is completely irrational.");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            yield return null;
        }

        characterBox.text = "Mr. Bingley"; //Surprised
        textController.say("What do you mean?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("First of all, I noticed that the woman did not have as much of her heart set in the relationship as you seemed to have. She was easily smiling and talking to others while you were pining after her.");
        yield return null;

        characterBox.text = "Mr. Bingley"; //Surprised
        textController.say("But...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("No, listen. Second of all, simply compare yourself to her. Her whole family’s salary combined is less than half of yours. She is from a different world.");
        yield return null;

        characterBox.text = "Mr. Bingley"; //Sad
        textController.say("But she...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("You need to trust me. This is the best option for your future. There are other women out there who are more deserving of you.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("The same principles apply to my situation with Elizabeth. I need to leave before it escalates.");
        yield return null;

        characterBox.text = "Mr. Bingley"; //Sad
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("*Sighs* Alright. Let’s go back to Beverly Hills.");
        yield return null;

        //UPTOWN LA
        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("It was probably a good idea to visit my aunt, Mayor de Bourgh, in LA.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        textController.think("Hold on...is that the girl from two months ago...Elizabeth...");
        yield return null;
        //Show Elizabeth and Catherine de Bourgh
        //Rose filter on Elizabeth

        characterBox.text = "Darcy Thoughts"; //Normal
        textController.think("Why is she still so beautiful after all these months? WHY?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hello Aunt Catherine.");
        yield return null;

        characterBox.text = "Mayor Catherine de Bourgh"; //Smiling
        textController.say("Darcy!");
        yield return null;

        characterBox.text = "Mayor Catherine de Bourgh"; //Smiling
        textController.say("My favorite nephew what a pleasure. I was just speaking with this young lady, Miss Elizabeth Bennet.");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Cold
        textController.say("*Coldly* Mr. Darcy.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("What do I say? What do I say? What do I say? What do I say?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Miss Elizabeth Bennet.");
        yield return null;

        characterBox.text = "Mayor Catherine de Bourgh"; //Cold
        textController.say("Well...that’s nice, you two are already acquainted. Why don’t you show her around LA Darcy. This woman has no appreciation for the classical arts. She couldn’t even recognize Mozart when it was played in front of her. I don’t think I can stand another minute of her low-class prattle.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why is my instinct to jump in and defend Elizabeth? That’s my aunt.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("I do not mind at all Aunt Catherine. We will take your leave then.");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Cold
        textController.say("*Coldly* Good day Mayor de Bourgh.");
        yield return null;

        //MALL
        //Sound of conversation
        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("And this is the LA Great Mall. That is Forever 21 and that is H&M and that is...");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why can I not stop thinking about her? Is this what love is? If that is the case, then I do understand where Bingley was coming from. I am even willing to propose right now to get married.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        textController.think("But what should I say when I propose?");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        textController.think("But what should I say when I propose?");
        choiceController.offerChoices("Despite the fact that you are in a much lower position in life, don’t have very much money at all, and no social standing, I love you. Please marry me.", "I sincerely love you. Please marry me.", "The only reason I’m asking to marry you is I have always wanted to hug someone else instead of hugging Mr. Teddy the teddy bear as a substitute.");
        choosing = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            characterBox.text = "Elizabeth Bennet"; //Weird
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("What?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("I am willing to marry you even though you would provide no benefit to me. You are relatively poor, have low tastes, and not to mention have just 4 friends on facebook, but I am willing to look past all that and ask you to marry me.");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            characterBox.text = "Elizabeth Bennet"; //Weird
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("What?");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("I am willing to marry you even though you would provide no benefit to me. You are relatively poor, have low tastes, and not to mention have just 4 friends on facebook, but I am willing to look past all that and ask you to marry me.");
            yield return null;
        }

        characterBox.text = "Elizabeth Bennet"; //Angry
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("There is no way I am ever marrying you!");
        yield return null;
        //Silence

        characterBox.text = "Mr. Darcy"; //Worried
        textController.say("Why?");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Angry
        textController.say("For real? Do you really think I would marry you with such a garbage proposal. Also, during our first time meeting you plainly called me ugly. Not only that, you caused my friend Wickham a lot of grief and I’m sure you had something to do with Jane and Bingley’s breakup. Jane is completely heartbroken because of you.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Surprised
        textController.say("Wickham! Wickham is lying scum...Also, Bingley and Jane...I...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Angry
        textController.say("Oh really. Then who do I believe. The lying scum? Or the scum who called me ugly to my face?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Worried
        textController.say("*Mumbles* To be fair, eavesdropping is rude...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //Angry
        textController.say("I don’t want to hear anymore! I’m already angry you had the nerve to propose to me. Let’s go back. I need to leave this place.");
        yield return null;

        //DARCY'S ROOM
    }
}
