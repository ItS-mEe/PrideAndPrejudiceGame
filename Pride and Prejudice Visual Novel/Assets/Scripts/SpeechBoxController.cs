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
    public Transform parentOfCharacters;
    public EffectController effectController;
    public GameObject email;
    
    public GameObject 
    catherinePrefab, elizabethPrefab, 
    georgianaPrefab, janePrefab, 
    lydiaPrefab, msBingleyPrefab, 
    mrBingleyPrefab, mrGardinerPrefab, 
    mrDarcyPrefab, mrsBennetPrefab, 
    wickhamPrefab, mrBennetPrefab;

    private CharacterEmotionController 
    catherine, elizabeth, 
    georgiana, jane, 
    lydia, msBingley, 
    mrBingley, mrGardiner, 
    mrDarcy, mrsBennet, 
    wickham, mrBennet;


    private IEnumerator script;
    private bool paused;
    private int choice;

    void Start(){
        script = GetScript();
        Invoke("moveNext", 1f/24);

        // INITNALIZATION
        catherine  = Instantiate(catherinePrefab).GetComponent<CharacterEmotionController>();
        elizabeth  = Instantiate(elizabethPrefab).GetComponent<CharacterEmotionController>();
        georgiana  = Instantiate(georgianaPrefab).GetComponent<CharacterEmotionController>();
        jane       = Instantiate(janePrefab).GetComponent<CharacterEmotionController>();
        lydia      = Instantiate(lydiaPrefab).GetComponent<CharacterEmotionController>();
        msBingley  = Instantiate(msBingleyPrefab).GetComponent<CharacterEmotionController>();
        mrBingley  = Instantiate(mrBingleyPrefab).GetComponent<CharacterEmotionController>();
        mrGardiner = Instantiate(mrGardinerPrefab).GetComponent<CharacterEmotionController>();
        mrDarcy    = Instantiate(mrDarcyPrefab).GetComponent<CharacterEmotionController>();
        mrsBennet  = Instantiate(mrsBennetPrefab).GetComponent<CharacterEmotionController>();
        wickham    = Instantiate(wickhamPrefab).GetComponent<CharacterEmotionController>();
        mrBennet   = Instantiate(mrBennetPrefab).GetComponent<CharacterEmotionController>();
        
    }

    private void moveNext(){
        script.MoveNext();
    }
    public void onClick(){
        if(paused){
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
        paused = false;
        this.choice = choice;
        this.onClick();
    }

    public void transitionDone(){
        paused = false;
        this.onClick();
    }

    public void midTransition(){
        script.MoveNext();
    }

    private IEnumerator GetScript(){
        //INIT
        double scale = 1.2 * Screen.height;
        catherine .gameObject.SetActive(false);
        catherine .transform.SetParent(parentOfCharacters);
        ((catherine .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        catherine.scale = (int)(scale/3);
        georgiana .gameObject.SetActive(false);
        georgiana .transform.SetParent(parentOfCharacters);
        ((georgiana .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        georgiana.scale = (int)(scale /3);
        jane      .gameObject.SetActive(false);
        jane      .transform.SetParent(parentOfCharacters);
        ((jane      .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        jane.scale = (int)(scale /3);
        lydia     .gameObject.SetActive(false);
        lydia     .transform.SetParent(parentOfCharacters);
        ((lydia     .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        lydia.scale = (int)(scale /3);
        msBingley .gameObject.SetActive(false);
        msBingley .transform.SetParent(parentOfCharacters);
        ((msBingley .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        msBingley.scale = (int)(scale /3);
        mrBingley .gameObject.SetActive(false);
        mrBingley .transform.SetParent(parentOfCharacters);
        ((mrBingley .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        mrBingley.scale = (int)(scale /3);
        mrGardiner.gameObject.SetActive(false);
        mrGardiner.transform.SetParent(parentOfCharacters);
        ((mrGardiner.transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        mrGardiner.scale = (int)(scale /3);
        mrDarcy   .gameObject.SetActive(true);
        mrDarcy   .transform.SetParent(parentOfCharacters);
        ((mrDarcy   .transform) as RectTransform ).anchoredPosition = new Vector3(0, Screen.height, 0);
        mrDarcy.scale = (int)(scale /3);
        mrsBennet .gameObject.SetActive(false);
        mrsBennet .transform.SetParent(parentOfCharacters);
        ((mrsBennet .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        mrsBennet.scale = (int)(scale /3);
        wickham   .gameObject.SetActive(false);
        wickham   .transform.SetParent(parentOfCharacters);
        ((wickham   .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        wickham.scale = (int)(scale /3);
        mrBennet  .gameObject.SetActive(false);
        mrBennet  .transform.SetParent(parentOfCharacters);
        ((mrBennet  .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        mrBennet.scale = (int)(scale /3);
        elizabeth.gameObject.SetActive(false);
        elizabeth.transform.SetParent(parentOfCharacters);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        elizabeth.scale = (int)(scale / 3);

        // Mr Bingley asks Mr Darcy to go with him to the party
        MonoBehaviour.print(Screen.height);
        mrBingley.gameObject.SetActive(true);
        mrBingley.currentView = "home";
        mrBingley.emotion = 5;
        backgroundImageController.location = 4;
        characterBox.text = "Mr Bingley"; //Smiling
        textController.say("Hey Darcy, want to go to Tim Cook's social with me? There will be cute girls I swear, and anyways, we are visiting the Apple headquarters in Cupertino anyways.");
        yield return null;
        
        mrBingley.emotion = 4;
        choiceController.offerChoices("I would rather stay in the hotel and read.", "I will go with you, but only to meet new connections.", "Only if you go as my date.");
        paused = true;
        yield return null;
      
        if(choice == 1){
            //dialogue for choice 1
            mrBingley.emotion = 5;
            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("Reading? You're so old fashioned. Come on. Please. Please. I'll be lonely.");
            yield return null;

            mrBingley.emotion = 4;
            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Fine. Whatever.");
            yield return null;

        } else if (choice == 2) {
            //dialogue for choice 2
            mrBingley.emotion = 5;
            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("Yaay!");
            yield return null;

        } else {
            //dialogue for choice 3
            mrBingley.emotion = 7;
            characterBox.text = "Mr. Bingley"; //Confused
            textController.say("What?");
            yield return null;


            characterBox.text = "Mr. Darcy"; //Normal
            mrBingley.emotion = 6;
            textController.say("Sorry, I have autocorrect in my brain sometimes.");
            yield return null;

            mrBingley.emotion = 5;
            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("So are you coming or not?");
            yield return null;

            mrBingley.emotion = 4;
            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Fine. Whatever.");
            yield return null;

        }

        mrBingley.gameObject.SetActive(false);

        // SOCIAL PARTY #1
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;

        backgroundImageController.location = 13;
        yield return null;

        ((msBingley  .transform) as RectTransform ).anchoredPosition = new Vector3(0, -30, 0);
        msBingley.gameObject.SetActive(true);
        msBingley.currentView = "home"; // really ball view ball stuff got put into home view
        msBingley.emotion = 9;
        characterBox.text = "Miss Bingley"; //Smiling
        textController.say("Hey, Mr. Darcy. You made it. How do you like the party?");
        yield return null;

        msBingley.emotion = 8;
        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("It's ok.");
        yield return null;

        msBingley.emotion = 7;
        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("I know right. Like, there are some people at this party that don't even deserve to be here, am I right? Like, what is wrong with society right now.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("When I heard about this party I thought only the richest of the rich would come, but now, I'm, like, surrounded by poor peasants.");
        yield return null;

        msBingley.emotion = 6;
        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("Well, yes. Anyways, I have some urgent business with your brother so I  must excuse myself.");
        yield return null;
        //Exit Miss Bingley
        msBingley.gameObject.SetActive(false);

        //Enter Mr Bingley
        mrBingley.gameObject.SetActive(true);
        mrBingley.currentView = "ball";
        mrBingley.emotion = 3;

        characterBox.text = "Mr. Bingley"; //Grinning
        textController.say("So are you enjoying yourself? Isn't this party really nice?");
        yield return null;

        mrBingley.emotion = 2;
        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("It's so-so.");
        yield return null;

        //Enter Elizabeth and Jane
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "ball";
        elizabeth.emotion = 3;
        jane.gameObject.SetActive(true);
        jane.currentView = "ball";
        jane.emotion = 2;
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.25), -30, 0);
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((mrBingley.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.25), -30, 0);
        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("Who are these people you have brought with you?");
        yield return null;

        jane.emotion = 3;
        characterBox.text = "Girl #1"; //Smiling
        textController.say("Hi, my name is Jane Bennet. It is a pleasure to meet you.");
        yield return null;
        jane.emotion = 2;

        elizabeth.emotion = 4;
        characterBox.text = "Girl #2"; //Bored
        textController.say("Elizabeth Bennet. Likewise.");
        yield return null;
        elizabeth.emotion = 3;

        characterBox.text = "Darcy Thoughts";//Weird
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Oh no, new people?! YIKES. How do I approach this situation?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Weird
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("*Stiffens* Hello, It is a pleasure to meet you both.");
        yield return null;

        jane.emotion = 0;
        mrBingley.emotion = 0;
        characterBox.text = "Mr. Darcy"; //Weird
        textController.say("My name is Fitzwilliam Darcy.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Weird
        textController.say("It is alright to call me Darcy.");
        yield return null;

        jane.emotion = 1;
        characterBox.text = "Jane Bennet"; //Concerned
        textController.say("Are you alright Mr. Darcy? You seem tense.");
        yield return null;
        jane.emotion = 0;

        characterBox.text = "Darcy Thoughts"; //Weird
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("She is catching on, come on Darcy, think of something, quick!");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Weird
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("*Still stiff* I'm fine, I simply have claustrophobia. This room is a little too small for my taste.");
        yield return null;

        elizabeth.emotion = 8;
        characterBox.text = "Elizabeth Bennet"; //laughing
        textController.say("...");
        yield return null;
        elizabeth.emotion = 9;

        jane.emotion = 1;
        characterBox.text = "Jane Bennet"; //Concerned
        textController.say("Alright.");
        yield return null;
        jane.emotion = 0;
        //Chatting continues. Jane and Elizabeth leave.
        elizabeth.gameObject.SetActive(false);
        jane.gameObject.SetActive(false);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((mrBingley.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);

        mrBingley.emotion = 1;
        characterBox.text = "Mr. Bingley"; //Concerned
        textController.say("Were you alright there Darcy? What happened?");
        yield return null;
        mrBingley.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Angry
        textController.say("Never mind that, this party is a lot worse than you implied in our previous exchange.");
        yield return null;

        mrBingley.emotion = 6;
        characterBox.text = "Mr. Bingley"; //Surprised
        textController.say("What are you talking about? There are lots of beautiful women everywhere!");
        yield return null;
        mrBingley.emotion = 5;

        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("What are YOU talking about? There is literally only one woman worth considering at this party, and that is the Miss Jane Bennet you brought over and danced with earlier.");
        yield return null;

        mrBingley.emotion = 4;
        characterBox.text = "Mr. Bingley"; //Normal
        textController.say("Yes she was really pretty... Anyways, I still think you're delusional buddy. What about her sister Elizabeth? She was nice.");
        yield return null;
        //Show Elizabeth (Normal)
        elizabeth.scale = (int)(scale / 5);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(-500, -165, 0);
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "ball";
        elizabeth.emotion = 9;

        characterBox.text = "Mr. Darcy"; //Bored
        textController.say("She is passable at best.");
        elizabeth.emotion = 0;
        yield return null;
        //Elizabeth Angry Expression
        elizabeth.gameObject.SetActive(false);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        elizabeth.scale = (int)(scale / 3);
        mrBingley.gameObject.SetActive(false);

        //BLACK SCREEN
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("As time passed, my opinion of her slowly started to change");
        backgroundImageController.location = 14;
        effectController.paused = true; this.paused = false;
        yield return null;

        effectController.paused = false; this.paused = true;
        yield return null;

        //SOCIAL PARTY #2
        //Darcy (Content) sees Elizabeth laughing. Rose filter.
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "ball";
        elizabeth.emotion = 8;
        characterBox.text = "Darcy Thoughts"; //Weird
        textController.think("Wow, Mr. Bingley was right. Elizabeth is really pretty.");
        yield return null;

        effectController.stopRoseFilter();
        elizabeth.scale = (int)(scale / 3);
        elizabeth.gameObject.SetActive(false);
        msBingley.gameObject.SetActive(true);
        msBingley.currentView = "home";
        msBingley.emotion = 3;
        characterBox.text = "Miss Bingley"; //Annoyed
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("...rcy. Hey! Darcy! What's wrong with you?");
        yield return null;
        msBingley.emotion = 2;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("Huh, oh. Sorry, I was distracted.");
        yield return null;

        msBingley.emotion = 3;
        characterBox.text = "Miss Bingley"; //Annoyed
        textController.say("I've noticed you've been staring at that Elizabeth girl in all the parties recently. Explain yourself.");
        yield return null;
        choiceController.offerChoices("I actually have really started to admire her.", "No, I have not been. I don't know what you are talking about?", "Her face is like one one of those oddly satisfying gifs. Its, well, oddly satisfying.");
        msBingley.emotion = 2;
        paused = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            msBingley.emotion = 3;
            characterBox.text = "Miss Bingley"; //Annoyed
            textController.say("That sounds like the most rehearsed lie I have ever heard. What is the truth?");
            yield return null;
            msBingley.emotion = 2;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("She has this sort of charm to her...");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            msBingley.emotion = 5;
            characterBox.text = "Miss Bingley"; //Surprised
            textController.say("Is there something wrong with you? Is there something going on in your life right now?");
            yield return null;
            msBingley.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("*Sighs* I was trying to dodge the question. The truth is, she is really quite attractive.");
            yield return null;
        }

        msBingley.emotion = 1;
        characterBox.text = "Miss Bingley"; //Angry
        textController.say("What! How could you! She is part of the working class.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Angry
        textController.say("She doesn't, like, even come close to deserving you.");
        yield return null;

        characterBox.text = "Miss Bingley"; //Angry
        textController.say("Her father makes only a measly 500,000 dollars per year while you, like, live in the biggest mansion in Beverly Hills.");
        yield return null;
        msBingley.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("I know, I know. That is why I still have not talked to her. She is not worth my time and effort.");
        yield return null;

        msBingley.emotion = 5;
        characterBox.text = "Miss Bingley"; //Normal
        textController.say("Good. Now let us continue with the party.");
        yield return null;
        msBingley.emotion = 4;

        msBingley.gameObject.SetActive(false);
        //HOTEL
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 9;
        yield return null;
        //Jane comes in and looks Sick
        jane.gameObject.SetActive(true);
        jane.currentView = "ball";
        jane.emotion = 6;
        characterBox.text = "Darcy Thoughts"; //Surprised
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Wow, she looks horrible. Is that a bicycle outside?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Surprised
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("When Bingley invited you I never imagined you would have come by bicycle, especially considering it is currently raining and you live in Sunnyvale.");
        yield return null;

        jane.emotion = 7;
        characterBox.text = "Jane Bennet"; //Sick
        textController.say("*Coughing* Yes my mother convinced me to come by bike instead of taking an uber.");
        yield return null;
        jane.emotion = 6;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("You should rest on our beds. You look mortifying.");
        yield return null;

        //Exit Jane
        jane.gameObject.SetActive(false);
        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("...");
        yield return null;

        //Enter Elizabeth. Rose filter.
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "home";
        elizabeth.emotion = 4;
        //Darcy Shakes himself himself out of it.
        characterBox.text = "Darcy Thoughts"; //Blushing
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why does she look so good right now? What is wrong with me?");
        yield return null;

        effectController.stopRoseFilter();
        elizabeth.scale = (int)(scale / 3);
        characterBox.text = "Mr. Darcy"; //Blushing
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Why are you so flushed? I did not see a taxi pull into the driveway, did you run here?");
        yield return null;

        elizabeth.emotion = 5;
        characterBox.text = "Elizabeth Bennet"; //Flushed
        textController.say("*Coldly* Actually, yes. And can I see to Jane immediately please?");
        yield return null;
        elizabeth.emotion = 4;

        characterBox.text = "Darcy Thoughts"; //Surprised
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why does she still look so pretty.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Surprised
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Wow...");
        yield return null;

        textController.sayFastAdvance("Advances without waiting for player's input", this.gameObject);
        characterBox.text = "Mr. Darcy"; //Surprised
        textController.say("...I mean yes, yes..of course. Right this way.");
        yield return null;
        //Elizabeth leaves
        elizabeth.gameObject.SetActive(false);

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("...");
        yield return null;

        //Elizabeth comes back
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "home";
        elizabeth.emotion = 7;
        characterBox.text = "Elizabeth"; //Worried
        textController.say("Wow she looked horrible.");
        yield return null;

        characterBox.text = "Elizabeth"; //Worried
        textController.say("...");
        yield return null;

        characterBox.text = "Elizabeth"; //Worried
        textController.say("I'm going to stay here for a few days while she recovers.");
        yield return null;
        elizabeth.emotion = 6;
        elizabeth.gameObject.SetActive(false);

        //DARCY'S ROOM
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 4;
        yield return null;
        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("She stayed for two more days. We spend most of our time reading.");
        yield return null;

        //HOTEL
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 9;
        yield return null;

        msBingley.gameObject.SetActive(true);
        msBingley.currentView = "street";
        msBingley.emotion = 1;
        characterBox.text = "Miss Bingley"; //Bored
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("I'm tired of all this reading we keep doing! ");
        yield return null;

        characterBox.text = "Miss Bingley"; //Bored
        textController.say("...");
        yield return null;

        characterBox.text = "Miss Bingley"; //Bored
        textController.say("Elizabeth come here and talk me, I would like to get to know you better.");
        elizabeth.gameObject.SetActive(true);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3((int)(-0.15*scale), -30, 0);
        ((msBingley.transform) as RectTransform).anchoredPosition = new Vector3((int)(0.15 * scale), -30, 0);
        elizabeth.currentView = "home";
        elizabeth.emotion = 0; 
        yield return null;
        msBingley.emotion = 0;

        elizabeth.emotion = 1;
        characterBox.text = "Elizabeth Bennet"; //Annoyed
        textController.say("I was enjoying reading but I will talk with you anyway.");
        yield return null;
        elizabeth.emotion = 0;

        msBingley.emotion = 3;
        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("Isn't Mr. Darcy really boring. All he does is read books all day. He is almost like a person from the 1800s.");
        elizabeth.emotion = 2;
        yield return null;
        msBingley.emotion = 2;

        elizabeth.emotion = 3;
        characterBox.text = "Elizabeth Bennet"; //Grinning
        textController.say("Yes, quite.");
        yield return null;
        elizabeth.emotion = 2;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I can't stop thinking about her. What is wrong with me?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("The only the wrong with me is...");
        yield return null;

        //Mr. Bingley comes in
        msBingley.gameObject.SetActive(false);
        mrBingley.gameObject.SetActive(true);
        ((msBingley.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((mrBingley.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.15), -30, 0);
        mrBingley.currentView = "home";
        mrBingley.emotion = 1;
        characterBox.text = "Mr. Bingley"; //Grinning
        textController.say("Guys, stop your clich' conversation. Jane has recovered.");
        yield return null;
        mrBingley.emotion = 0;

        //Jane comes in
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.25), -30, 0);
        ((mrBingley.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.25), -30, 0);
        jane.gameObject.SetActive(true);
        jane.currentView = "ball";
        jane.emotion = 3;
        characterBox.text = "Jane Bennet"; //Smiling
        textController.say("Thank you all so much for your hospitality. I really appreciate all of you providing me with your hotel room to recover.");
        mrBingley.emotion = 4;
        yield return null;
        jane.emotion = 2;

        mrBingley.emotion = 5;
        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("It was no problem. I'm so happy I was able to spend time with you~");
        yield return null;
        mrBingley.emotion = 4;

        elizabeth.emotion = 1;
        characterBox.text = "Elizabeth Bennet"; //Normal
        textController.say("We will be leaving now. Thank you everyone for your hospitality.");
        yield return null;
        elizabeth.emotion = 0;
        //Jane and Elizabeth leave
        jane.gameObject.SetActive(false);
        elizabeth.gameObject.SetActive(false);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((mrBingley.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);

        mrBingley.emotion = 5;
        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("I really like Jane. I thought she was a really sweet and kind girl. I would love to get to know her more.");
        yield return null;
        mrBingley.emotion = 4;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("That's great. We can meet them again another time.");
        yield return null;
        mrBingley.gameObject.SetActive(false);

        //Scene cut. Fade to black.
        //GYM
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 8;
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Alright. My last errand for today is to cancel my gym membership.");
        yield return null;

        //Elizabeth, Jane, and Wickham appear on the screen
        elizabeth.gameObject.SetActive(true);
        jane.gameObject.SetActive(true);
        wickham.gameObject.SetActive(true);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.25), -30, 0);
        ((wickham.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.25), -30, 0);
        elizabeth.currentView = "street";
        jane.currentView = "street";
        wickham.currentView = "home";
        elizabeth.emotion = 3;
        jane.emotion = 2;
        wickham.emotion = 2;
        //Rose filter on Elizabeth
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Elizabeth Bennet"; //Blushing
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hehehe~");
        yield return null;
        elizabeth.emotion = 2;

        wickham.emotion = 3;
        characterBox.text = "Mr. Wickham"; //Smiling
        textController.say("No seriously. You really do.");
        yield return null;
        wickham.emotion = 2;
        //DJ record scratching sound effect

        effectController.stopRoseFilter();
        elizabeth.scale = (int)(scale / 3);
        characterBox.text = "Darcy Thoughts"; //Angry
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I despise that Wickham. The things he did ' I do not want to remember.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Angry
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I should...");
        yield return null;
        
        choiceController.offerChoices("ignore him and go about my business.", "confront Wickham and take Elizabeth.", "challenge him to a fight like Logan Paul and KSI.");
        paused = true;
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

        wickham.emotion = 0;
        characterBox.text = "Mr. Wickham"; //Cold
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("...");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Angry
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I will just finish my errand");
        yield return null;

        elizabeth.gameObject.SetActive(false);
        jane.gameObject.SetActive(false);
        wickham.gameObject.SetActive(false);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((wickham.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);

        //SOCIAL PARTY #3
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 15;
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        textController.say("I promised myself that I would ask Elizabeth to dance at this party, but I'm having second thoughts'");
        yield return null;
        //Elizabeth comes in
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "ball";
        elizabeth.emotion = 5;
        //Rose filter
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Darcy Thoughts"; //Blushing
        textController.think("Should I...");
        yield return null;
        
        choiceController.offerChoices("ask her to dance?", "wait until the next dance?", "teach her about the communist ideals of Karl Marx?");
        paused = true;
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
        textController.think("Let's charm her with my smile.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Blushing
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Can I have the honor of this dance?");
        yield return null;

        elizabeth.emotion = 12;
        characterBox.text = "Elizabeth Bennet"; //Surprised
        textController.say("...Uh...well..sure...");
        yield return null;
        elizabeth.emotion = 11;

        characterBox.text = "Darcy Thoughts"; //Surprised
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("It actually worked?!");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Uh, nice.");
        yield return null;

        //Make Elizabeth bigger
        elizabeth.scale = (int) scale/3 + 10;
        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("So...");
        yield return null;

        elizabeth.emotion = 1;
        characterBox.text = "Elizabeth Bennet"; //Awkward
        textController.say("...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("..Uh...How was your day?...");
        yield return null;

        elizabeth.emotion = 2;
        characterBox.text = "Elizabeth Bennet"; //Awkward
        textController.say("...Good...");
        yield return null;
        elizabeth.emotion = 1;

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

        elizabeth.emotion = 7;
        textController.sayFastAdvance("Advances without waiting for player's input", this.gameObject);
        characterBox.text = "Elizabeth Bennet"; //Interested
        textController.say("I saw you at the gym.");
        yield return null;
        elizabeth.emotion = 6;
        //Elizabeth gets smaller
        elizabeth.scale = (int) scale / 3;
        effectController.stopRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Mr. Darcy"; //Awkward
        textController.say("...Uh...yes");
        yield return null;

        elizabeth.emotion = 7;
        characterBox.text = "Elizabeth Bennet"; //Interested
        textController.say("I noticed your reaction to my friend Mr. Wickham.");
        yield return null;
        elizabeth.emotion = 6;

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

        textController.sayFastAdvance("Advances without waiting for player's input", this.gameObject);
        //Elizabeth leaves
        elizabeth.gameObject.SetActive(false);

        //Mrs. Bennet enters
        mrsBennet.gameObject.SetActive(true);
        mrsBennet.currentView = "ball";
        mrsBennet.emotion = 2;
        characterBox.text = "Mrs. Bennet"; //Cold
        textController.say("*Coldly*  Why hello Mr. Darcy.");
        yield return null;
        mrsBennet.emotion = 5;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Not her again.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hello Mrs. Bennet. How are you this fine evening?");
        yield return null;

        mrsBennet.emotion = 2;
        characterBox.text = "Mrs. Bennet"; //Cold
        textController.say("*Coldly* Just fine. Thank you.");
        yield return null;
        mrsBennet.emotion = 5;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why is she so uptight all the time? Was it something I said?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("To what do I owe the pleasure of this conversation to Mrs. Bennet?");
        mrsBennet.emotion = 4;
        yield return null;

        mrsBennet.emotion = 1;
        characterBox.text = "Mrs. Bennet"; //Happy
        textController.say("I'm sure you have heard already, but my Jane and Mr. Bingley are about to be engaged and I just wanted to tell you, I'm so excited.");
        yield return null;

        characterBox.text = "Mrs. Bennet"; //Happy
        textController.say("I need to plan the wedding already. We'll need flowers. The best ones are roses because they display love. But there are also lavenders for peace and all that jazz.");
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
        textController.say("And lavenders...Well, about to be, but yes. And a yellow dress to stand out of course...");
        yield return null;
        mrsBennet.emotion = 0;

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
        mrsBennet.gameObject.SetActive(false);

        //DARCY HOTEL ROOM
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 4;
        yield return null;

        mrBingley.gameObject.SetActive(true);
        mrBingley.currentView = "home";
        mrBingley.emotion = 5;
        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("Darcy, I'm excited. That woman Jane, she's amazing. She's smart, sweet, pretty, kind, and funny. I'm going to ask her to be my wife. What do you think?");
        yield return null;
        choiceController.offerChoices("Wait, but I was going to do that.", "That is greatest news I have ever heard come out of your mouth.", "Don't do it, think about your future.");
        mrBingley.emotion = 4;
        paused = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            mrBingley.emotion = 7;
            characterBox.text = "Mr. Bingley"; //Surprised
            textController.say("For real?");
            yield return null;
            mrBingley.emotion = 6;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("No, of course not. It is called sarcasm.");
            yield return null;

            mrBingley.emotion = 5;
            characterBox.text = "Mr. Bingley"; //Smiling 
            textController.say("What are your actual thoughts?");
            yield return null;
            mrBingley.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Speaking from logical standpoint, I think this marriage is completely irrational.");
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            mrBingley.emotion = 7;
            characterBox.text = "Mr. Bingley"; //Surprised
            textController.say("Wait, really, then why are you not smiling?");
            yield return null;
            mrBingley.emotion = 6;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("No, of course not. It is called sarcasm.");
            yield return null;

            mrBingley.emotion = 5;
            characterBox.text = "Mr. Bingley"; //Smiling
            textController.say("What are your actual thoughts?");
            yield return null;
            mrBingley.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("Speaking from logical standpoint, I think this marriage is completely irrational.");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            yield return null;
        }

        mrBingley.emotion = 7;
        characterBox.text = "Mr. Bingley"; //Surprised
        textController.say("What do you mean?");
        yield return null;
        mrBingley.emotion = 6;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("First of all, I noticed that the woman did not have as much of her heart set in the relationship as you seemed to have. She was easily smiling and talking to others while you were pining after her.");
        yield return null;

        mrBingley.emotion = 3;
        characterBox.text = "Mr. Bingley"; //Sad
        textController.say("But...");
        yield return null;
        mrBingley.emotion = 2;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("No, listen. Second of all, simply compare yourself to her. Her whole family's salary combined is less than half of yours. She is from a different world.");
        yield return null;

        mrBingley.emotion = 3;
        characterBox.text = "Mr. Bingley"; //Sad
        textController.say("But she...");
        yield return null;
        mrBingley.emotion = 2;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("You need to trust me. This is the best option for your future. There are other women out there who are more deserving of you.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("The same principles apply to my situation with Elizabeth. I need to leave before it escalates.");
        yield return null;

        mrBingley.emotion = 3;
        characterBox.text = "Mr. Bingley"; //Sad
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("*Sighs* Alright. Let's go back to Beverly Hills.");
        yield return null;
        mrBingley.emotion = 2;

        mrBingley.gameObject.SetActive(false);

        //UPTOWN LA
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 5;
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("It was probably a good idea to visit my aunt, Mayor de Bourgh, in LA.");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        textController.think("Hold on...is that the girl from two months ago...Elizabeth...");
        yield return null;
        //Show Elizabeth and Catherine de Bourgh
        ((catherine.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale *0.15), -30, 0);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.15), -30, 0);
        elizabeth.gameObject.SetActive(true);
        catherine.gameObject.SetActive(true);
        elizabeth.currentView = "street";
        catherine.currentView = "home";
        elizabeth.emotion = 10;
        catherine.emotion = 3;
        //Rose filter on Elizabeth
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Darcy Thoughts"; //Normal
        textController.think("Why is she still so beautiful after all these months? WHY?");
        yield return null;
        effectController.stopRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hello Aunt Catherine.");
        yield return null;

        catherine.emotion = 2;
        characterBox.text = "Mayor Catherine de Bourgh"; //Smiling
        textController.say("Darcy!");
        yield return null;

        characterBox.text = "Mayor Catherine de Bourgh"; //Smiling
        textController.say("My favorite nephew what a pleasure. I was just speaking with this young lady, Miss Elizabeth Bennet.");
        yield return null;
        catherine.emotion = 1;

        elizabeth.emotion = 11;
        characterBox.text = "Elizabeth Bennet"; //Cold
        textController.say("*Coldly* Mr. Darcy.");
        yield return null;
        elizabeth.emotion = 10;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("What do I say? What do I say? What do I say? What do I say?");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Miss Elizabeth Bennet.");
        catherine.emotion = 3;
        yield return null;

        catherine.emotion = 0;
        characterBox.text = "Mayor Catherine de Bourgh"; //Cold
        textController.say("Well...that's nice, you two are already acquainted. Why don't you show her around LA Darcy. This woman has no appreciation for the classical arts. She couldn't even recognize Mozart when it was played in front of her. I don't think I can stand another minute of her low-class prattle.");
        yield return null;
        catherine.emotion = 3;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Why is my instinct to jump in and defend Elizabeth? That's my aunt.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("I do not mind at all Aunt Catherine. We will take your leave then.");
        yield return null;

        elizabeth.emotion = 11;
        characterBox.text = "Elizabeth Bennet"; //Cold
        textController.say("*Coldly* Good day Mayor de Bourgh.");
        yield return null;
        elizabeth.emotion = 10;

        elizabeth.gameObject.SetActive(false);
        catherine.gameObject.SetActive(false);
        ((catherine.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);


        //MALL
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        elizabeth.gameObject.SetActive(true);
        yield return null;

        elizabeth.currentView = "street";
        elizabeth.emotion = 10;
        backgroundImageController.location = 12;
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
        
        choiceController.offerChoices("Despite the fact that you are in a much lower position in life, don't have very much money at all, and no social standing, I love you. Please marry me.", "I sincerely love you. Please marry me.", "The only reason I'm asking to marry you is I have always wanted to hug someone else instead of hugging Mr. Teddy the teddy bear as a substitute.");
        paused = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            elizabeth.emotion = 5;
            characterBox.text = "Elizabeth Bennet"; //Weird
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("What?");
            yield return null;
            elizabeth.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("I am willing to marry you even though you would provide no benefit to me. You are relatively poor, have low tastes, and not to mention have just 4 friends on facebook, but I am willing to look past all that and ask you to marry me.");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            elizabeth.emotion = 5;
            characterBox.text = "Elizabeth Bennet"; //Weird
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("What?");
            yield return null;
            elizabeth.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("I am willing to marry you even though you would provide no benefit to me. You are relatively poor, have low tastes, and not to mention have just 4 friends on facebook, but I am willing to look past all that and ask you to marry me.");
            yield return null;
        }

        elizabeth.emotion = 9;
        characterBox.text = "Elizabeth Bennet"; //Angry
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("There is no way I am ever marrying you!");
        yield return null;
        elizabeth.emotion = 8;
        //Silence

        characterBox.text = "Mr. Darcy"; //Worried
        textController.say("Why?");
        yield return null;

        elizabeth.emotion = 9;
        characterBox.text = "Elizabeth Bennet"; //Angry
        textController.say("For real? Do you really think I would marry you with such a garbage proposal. Also, during our first time meeting you plainly called me ugly. Not only that, you caused my friend Wickham a lot of grief and I'm sure you had something to do with Jane and Bingley's breakup. Jane is completely heartbroken because of you.");
        yield return null;
        elizabeth.emotion = 8;

        characterBox.text = "Mr. Darcy"; //Surprised
        textController.say("Wickham! Wickham is lying scum...Also, Bingley and Jane...I...");
        yield return null;

        elizabeth.emotion = 9;
        characterBox.text = "Elizabeth Bennet"; //Angry
        textController.say("Oh really. Then who do I believe. The lying scum? Or the scum who called me ugly to my face?");
        yield return null;
        elizabeth.emotion = 8;

        characterBox.text = "Mr. Darcy"; //Worried
        textController.say("*Mumbles* To be fair, eavesdropping is rude...");
        yield return null;

        elizabeth.emotion = 9;
        characterBox.text = "Elizabeth Bennet"; //Angry
        textController.say("I don't want to hear anymore! I'm already angry you had the nerve to propose to me. Let's go back. I need to leave this place.");
        yield return null;
        elizabeth.emotion = 8;

        elizabeth.gameObject.SetActive(false);

        //DARCY'S ROOM
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 4; //TODO change this
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Worried
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I need to write her an email. I have to explain myself or I will regret it.");
        yield return null;
        //Email image

        email.SetActive(true);

        characterBox.text = "Darcy Thoughts"; //Worried
        textController.think("It can not be written any better than this. Send.");
        yield return null;

        email.SetActive(false);

        //BEVERLY HILLS MANSION
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 1;
        yield return null;

        characterBox.text = "Mr. Darcy"; //Worried
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("*Thinking aloud* It has been a full week and Elizabeth has still responded to my email. I wonder if she read it and understood my situation.");
        yield return null;
        //Show Georgiana
        georgiana.gameObject.SetActive(true);
        georgiana.currentView = "home";
        georgiana.emotion = 1;

        characterBox.text = "Georgiana Darcy"; //Smiling
        textController.say("Brother!");
        yield return null;
        georgiana.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Smiling
        textController.say("Georgiana! There is my favorite little sister!");
        yield return null;

        georgiana.emotion = 3;
        characterBox.text = "Georgiana Darcy"; //Surprised
        textController.say("Who are they?");
        yield return null;
        georgiana.emotion = 2;

        characterBox.text = "Mr. Darcy"; //Surprised
        textController.say("*Turns around*");
        yield return null;
        //Show Elizabeth and Mr. Gardiner
        elizabeth.gameObject.SetActive(true);
        mrGardiner.gameObject.SetActive(true);
        ((mrGardiner.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.25), -30, 0);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((georgiana.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.25), -30, 0);
        elizabeth.currentView = "street";
        mrGardiner.currentView = "home";
        elizabeth.emotion = 16;
        mrGardiner.emotion = 0;
        //Rose filter on Elizabeth
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        elizabeth.emotion = 17;
        characterBox.text = "Elizabeth Bennet"; //Embarrassed
        textController.say("Um...Hi...Darcy...");
        yield return null;
        elizabeth.emotion = 16;

        characterBox.text = "Darcy Thoughts"; //Worried
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("She's here. Oh my god, please have a favorable response.");
        yield return null;
        effectController.stopRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hello Miss Elizabeth. A pleasure as always. And who is this respectable man?");
        yield return null;

        mrGardiner.emotion = 1;
        characterBox.text = "Mr. Gardiner"; //Normal
        textController.say("Hello Mr. Darcy, I am Edward Gardiner, Elizabeth's uncle. A pleasure. You seem much more polite than I was originally told.");
        yield return null;
        mrGardiner.emotion = 0;

        elizabeth.emotion = 17;
        characterBox.text = "Elizabeth Bennet"; //Embarrassed
        textController.say("Yes...Sorry, Uncle Gardiner. I appear to have been proven wrong.");
        yield return null;
        elizabeth.emotion = 16;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("Everything in the past is water under the bridge. You both must come for dinner. Elizabeth this is my sister, Georgiana.");
        yield return null;

        georgiana.emotion = 1;
        characterBox.text = "Georgiana Darcy"; //Smiling
        textController.say("Hello Miss Elizabeth. I hope we can chat with each other a decent amount later.");
        yield return null;
        georgiana.emotion = 0;

        elizabeth.emotion = 17;
        characterBox.text = "Elizabeth Bennet"; //Embarrassed
        textController.say("You seem...a lot different than...");
        yield return null;
        elizabeth.emotion = 16;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I need to get her to like me during dinner.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Well, since we are done with the formalities, please come inside. Miss Bingley will be joining us as well.");
        yield return null;
        elizabeth.gameObject.SetActive(false);
        mrGardiner.gameObject.SetActive(false);
        georgiana.gameObject.SetActive(false);
        ((mrGardiner.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((georgiana.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);

        //DINNER SCENE
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 6;
        yield return null;

        //Show just Elizabeth
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "street";
        elizabeth.emotion = 0;
        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Come on Darcy, try to impress her. There has to be something I can do to get her to like me.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Miss Elizabeth please allow me to pass you the sauce.");
        elizabeth.emotion = 4;
        yield return null;

        elizabeth.emotion = 5;
        characterBox.text = "Elizabeth Bennet"; //Weird
        textController.say("Oh...Umm...Sure...");
        yield return null;

        elizabeth.emotion = 7;
        characterBox.text = "Elizabeth Bennet"; //Smiling
        textController.say("Thanks");
        yield return null;
        elizabeth.emotion = 6;
        //Rose Filter
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Mr. Darcy"; //Blushing
        textController.say("*Looks away* No problem.");
        yield return null;
        effectController.stopRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        elizabeth.gameObject.SetActive(false);

        //LIVING ROOM
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 11;
        yield return null;

        msBingley.gameObject.SetActive(true);
        msBingley.currentView = "ball";
        msBingley.emotion = 3;
        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("What a boorish dinner. Did you see Elizabeth, she was so plain and quiet at the dinner.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("...");
        yield return null;

        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("I mean she really doesn't know how to, like, dress to impress, if you know what I mean.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("...");
        yield return null;

        characterBox.text = "Miss Bingley"; //Sassy
        textController.say("And did you see? She wasn't even wearing any eyeliner! UGH! I'd give her, like, a two on a good day.");
        yield return null;
        msBingley.emotion = 2;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("I used to be of the same opinion, but now I consider to be the prettiest woman I know.");
        yield return null;

        msBingley.emotion = 1;
        characterBox.text = "Miss Bingley"; //Angry
        textController.say("How could you even say that? Do you see all the moisturizer and makeup use? I have, like, a professional fashion adviser. I'm an accomplished professional model. How can she even be close to my level, like, seriously.");
        yield return null;
        msBingley.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("These are all true facts, but because of Elizabeth my perspective of the world and how I view people's worth has changed. What matters more to me right now is feelings.");
        yield return null;

        msBingley.gameObject.SetActive(false);

        //ELIZABETH'S ROOM
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 7;
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("I want to see Elizabeth.");
        yield return null;

        //Show Elizabeth off to the side crying
        elizabeth.gameObject.SetActive(true);
        elizabeth.currentView = "street";
        elizabeth.emotion = 12;

        characterBox.text = "Darcy Thoughts"; //Worried
        textController.think("Wait...Is she crying?");
        yield return null;

        characterBox.text = "Darcy Thoughts"; //Normal
        textController.think("Oh no, what do I do?");
        yield return null;
        
        choiceController.offerChoices("Ask: What's wrong?", "Ignore her.", "I know it's really sad that a 23 Jump Street is not coming out, but there is no need to cry about it.");
        paused = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            characterBox.text = "Darcy Thoughts"; //Normal
            textController.say("There is no way I am going to get her to like me if I ignore her here.");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Normal
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("Did something happen? You can tell me anything.");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            //Center Elizabeth
            elizabeth.emotion = 13;
            characterBox.text = "Elizabeth Bennet"; //Crying
            characterBox.fontStyle = FontStyle.Normal;
            textController.say("Jokes are not going to cheer me up in this situation Darcy.");
            yield return null;
            elizabeth.emotion = 12;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("I apologize, I thought I would try to cheer you up. Did something happen? You can tell me anything.");
            yield return null;
        }

        elizabeth.emotion = 13;
        characterBox.text = "Elizabeth Bennet"; //Crying
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("...");
        yield return null;
        elizabeth.emotion = 12;

        characterBox.text = "Mr. Darcy"; //Determined
        textController.say("I can wait here however long it takes for you to open up to me.");
        yield return null;

        elizabeth.emotion = 13;
        characterBox.text = "Elizabeth Bennet"; //Crying
        textController.say("...Wickham managed to provoke my 19 year old little sister *sniff* Lydia *sniff* into eloping with him to Las Vegas.");
        yield return null;
        elizabeth.emotion = 12;

        characterBox.text = "Mr. Darcy"; //Surprised
        textController.say("Oh no! This is all my fault. I did not reveal to your family the truth about Wickham.");
        yield return null;

        elizabeth.emotion = 13;
        characterBox.text = "Elizabeth Bennet"; //Crying
        textController.say("*Sniff* No it's mine. I did not tell them either, even after you told me about him. Now my father is struggling to find them in Las Vegas.");
        yield return null;
        elizabeth.emotion = 12;

        characterBox.text = "Mr. Darcy"; //Determined
        textController.say("We need to act fast so nothing horrible happens. First, take this tissue and wipe your face.");
        elizabeth.emotion = 14;
        yield return null;
        //Change Elizabeth Face to determined

        elizabeth.emotion = 15;
        characterBox.text = "Elizabeth Bennet"; //Determined
        textController.say("Thank you.");
        yield return null;
        elizabeth.emotion = 14;

        characterBox.text = "Mr. Darcy"; //Determined
        textController.say("No problem. Now let us proceed quickly. You go comfort your family in these dark times. I will fly to Las Vegas in my private jet and assist your father.");
        yield return null;

        elizabeth.emotion = 15;
        characterBox.text = "Elizabeth Bennet"; //Determined
        textController.say("Ok. Please find them Mr. Darcy.");
        yield return null;
        elizabeth.emotion = 14;

        characterBox.text = "Mr. Darcy"; //Determined
        textController.say("Of course.");
        yield return null;

        elizabeth.gameObject.SetActive(false);

        //LAS VEGAS
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 10;
        yield return null;

        ((wickham.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.15), -30, 0);
        ((lydia.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.15), -30, 0);
        wickham.gameObject.SetActive(true);
        lydia.gameObject.SetActive(true);
        wickham.currentView = "home";
        lydia.currentView = "home";
        wickham.emotion = 3;
        lydia.emotion = 3;
        characterBox.text = "Mr. Darcy"; //Angry
        textController.say("Wickham! I finally found you, you scumbag!");
        yield return null;

        wickham.emotion = 0;
        lydia.emotion = 2;
        characterBox.text = "Lydia Bennet"; //Sassy
        textController.say("Hey, don't call him that!");
        yield return null;
        lydia.emotion = 1;


        characterBox.text = "Mr. Darcy"; //Angry
        textController.say("You stay out of this. Let the adults talk. It took me a 1 hour plane ride, a wide distribution of money, and several phone calls to find you. Mr. Bennet even gave up before I found you.");
        yield return null;

        wickham.emotion = 1;
        characterBox.text = "Mr. Wickham"; //Closed
        textController.say("Hey man, chill out. We aren't doing anything wrong. We are in love and going to get married for sure. What's the big deal?");
        yield return null;
        wickham.emotion = 0;

        lydia.emotion = 2;
        characterBox.text = "Lydia Bennet"; //Sassy
        textController.say("Yeah, I love him~");
        yield return null;
        lydia.emotion = 1;

        characterBox.text = "Mr. Darcy"; //Angry
        textController.say("Again, you be quiet, and don't give me that Wickham. Let her go now before you stain her reputation or do something else horrendous.");
        yield return null;

        wickham.emotion = 1;
        characterBox.text = "Mr. Wickham"; //Closed
        textController.say("What's with you man? For one thing, why do you always talk like some character from the 1800s?");
        yield return null;
        wickham.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Angry
        textController.say("I'm in no mood for jokes Wickham. End this facade or else.");
        yield return null;

        wickham.emotion = 1;
        characterBox.text = "Mr. Wickham"; //Closed
        textController.say("Alright I'll cut you a deal. If I get two hundred thousand dollars and fifty thousand a year I will marry the girl.");
        yield return null;
        wickham.emotion = 0;

        choiceController.offerChoices("Well...Alright...People already know of your elopement anyways. It will save everyone face if you get married.", "I will give you only one hundred thousand dollars, but still include your other portion.", "Or we put aside the money, and I can set you up with with a private meeting with Pewdiepie.");
        paused = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            wickham.emotion = 1;
            characterBox.text = "Mr. Wickham"; //Closed
            textController.say("Two hundred thousand dollars. No more, no less.");
            yield return null;
            wickham.emotion = 0;

            characterBox.text = "Mr. Darcy"; //Angry
            textController.say("One hundred and fifty thousand.");
            yield return null;

            wickham.emotion = 1;
            characterBox.text = "Mr. Wickham"; //Closed
            textController.say("Two hundred thousand dollars. No more, no less.");
            yield return null;
            wickham.emotion = 0;

            characterBox.text = "Mr. Darcy"; //Annoyed
            textController.say("*Sigh* Fine, a lot people were already gossiping. At least marriage will stop that.");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            wickham.emotion = 1;
            characterBox.text = "Mr. Wickham"; //Closed
            textController.say("Hmmm...That's' tough. I do like Pewdiepie, but I'm going to have to go with the money.");
            yield return null;
            wickham.emotion = 0;

            characterBox.text = "Mr. Darcy"; //Annoyed
            textController.say("*Sigh* Fine, a lot people were already gossiping. At least marriage will stop that.");
            yield return null;
        }

        lydia.emotion = 0;
        characterBox.text = "Lydia Bennet"; //Smiling
        textController.say("Oh my god, Wickham you're so smart. I can't believe Darcy was dumb enough to give you the money even though you were going to marry me anyways.");
        yield return null;
        lydia.emotion = 3;

        wickham.emotion = 3;
        characterBox.text = "Mr. Wickham"; //Grinning
        textController.say("Yes darling. You're exactly right.");
        yield return null;
        wickham.emotion = 2;

        characterBox.text = "Mr. Darcy"; //Annoyed
        textController.say("Well, now that this situation is over with. Let us have you two get married and move on with our lives.");
        yield return null;
        //Bad flute wedding music
        wickham.gameObject.SetActive(false);
        lydia.gameObject.SetActive(false);
        ((wickham.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.15), -30, 0);
        ((lydia.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.15), -30, 0);

        //BEVERLY HILLS STREET
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 2;
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("Bingley, I finally found you!");
        yield return null;

        mrBingley.gameObject.SetActive(true);
        mrBingley.currentView = "street";
        mrBingley.emotion = 5;

        characterBox.text = "Mr. Bingley"; //Sad
        textController.say("What is it Darcy? Have you come to tell me I am wrong with another choice in my life as well?");
        yield return null;
        mrBingley.emotion = 4;

        characterBox.text = "Mr. Darcy"; //Desperate
        textController.say("No, Bingley, you must understand. I was wrong before. I now realize how entrancing that situation was for you.");
        yield return null;

        mrBingley.emotion = 7;
        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("You do?");
        yield return null;
        mrBingley.emotion = 6;

        characterBox.text = "Mr. Darcy"; //Embarrassed
        textController.say("Yes, and that's why you need to go back to Cupertino right now and propose to her.");
        yield return null;

        mrBingley.emotion = 7;
        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("But I literally have nothing prepared to propose to her. What would I do?");
        yield return null;
        mrBingley.emotion = 6;

        choiceController.offerChoices("Sneak up behind hear, cover her eyes, and whisper in her ear 'You will marry me.'", "Tell her how you sincerely feel and propose to her. I am sure she will accept.", "Tell her you have a special surprise set up in another location. Ask her to cover her eyes and then ditch her.");
        paused = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            mrBingley.emotion = 1;
            characterBox.text = "Mr. Bingley"; //Confused
            textController.say("Isn't that inappropriate for this situation?");
            yield return null;
            mrBingley.emotion = 0;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("*Sigh* Fine. Go about it the normal way then. Give her the whole clich' speech about emotions and then get down on your knees and say the normal phrase.");
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            mrBingley.emotion = 1;
            characterBox.text = "Mr. Bingley"; //Confused
            textController.say("Wait... why would I do that when I want to marry her?");
            yield return null;
            mrBingley.emotion = 0;

            characterBox.text = "Mr. Darcy"; //Normal
            textController.say("*Sigh* Fine. Go about it the normal way then. Give her the whole clich' speech about emotions and then get down on your knees and say the normal phrase.");
            yield return null;
        }

        mrBingley.emotion = 7;
        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("Thank you! Thank you so much Darcy! I'm so happy. Oh my god, I'm going to tell everyone about this on my Tweeter and Snapstagram.");
        yield return null;
        mrBingley.emotion = 6;

        characterBox.text = "Mr. Darcy"; //Smiling
        textController.say("We should fly there now. I believe in you.");
        yield return null;

        mrBingley.gameObject.SetActive(false);

        //BENNET HOME
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 0;
        yield return null;

        mrBennet.gameObject.SetActive(true);
        mrBennet.currentView = "home";
        mrBennet.emotion = 1;
        characterBox.text = "Mr. Bennet"; //Cold
        textController.say("What can I do you for Mr. Darcy?");
        yield return null;
        mrBennet.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Nervous
        textController.say("Umm...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Nervous
        textController.say("I have something to tell you...");
        yield return null;

        mrBennet.emotion = 1;
        characterBox.text = "Mr. Bennet"; //Cold
        textController.say("What is it?");
        yield return null;
        mrBennet.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Nervous
        textController.say("Well...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Determined
        textController.say("I would like to ask for your daughter's hand in marriage.");
        yield return null;

        mrBennet.emotion = 5;
        characterBox.text = "Mr. Bennet"; //Resigned
        textController.say("*Sighs* Ultimately, I realize you are a powerful man and that you will provide well for my daughter. The issue is though, that your personality is a bit of a bother to me and I am not completely sure that you will make my daughter happy. In the end though, the choice comes down to Elizabeth. It's 2019 and women have the right to choose for themselves.");
        yield return null;
        mrBennet.emotion = 4;

        characterBox.text = "Mr. Darcy"; //Smiling
        textController.say("Please ask your daughter then Mr. Bennet. I'm sure you will be amazed.");
        yield return null;

        mrBennet.emotion = 3;
        characterBox.text = "Mr. Bennet"; //Confused
        textController.say("Alright. Please wait outside.");
        yield return null;

        characterBox.text = "Mr. Bennet"; //Confused
        textController.say("Elizabeth!");
        yield return null;
        mrBennet.emotion = 2;

        mrBennet.gameObject.SetActive(false);

        //CUPERTINO STREET
        effectController.fadeToBlack(this.gameObject); paused = true;
        yield return null;
        backgroundImageController.location = 3;
        yield return null;

        //On screen is Mr. Bingley
        mrBingley.gameObject.SetActive(true);
        mrBingley.currentView = "street";
        mrBingley.emotion = 3;
        characterBox.text = "Mr. Bingley"; //Nervous
        textController.say("I'm really nervous...what if she says no?");
        yield return null;
        mrBingley.emotion = 2;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("I am sure that you will do great. You always had natural charm...In addition, why would she say no? She is in love...");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("And you have over 135 million people following you on Snapstagram.");
        yield return null;

        mrBingley.emotion = 1;
        characterBox.text = "Mr. Bingley"; //Less Nervous
        textController.say("I wish I had your confidence.");
        yield return null;
        mrBingley.emotion = 0;

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("Just stick to the plan: Elizabeth and I are to separate off from the two of you, then you must get down on your knee and propose. How simple could it be?");
        yield return null;

        mrBingley.emotion = 3;
        characterBox.text = "Mr. Bingley"; //Nervous
        textController.say("Here they come! Wish me luck!");
        yield return null;
        mrBingley.emotion = 2;

        //Elizabeth and Jane Enter
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3((int)(scale * 0.25), -30, 0);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((mrBingley.transform) as RectTransform).anchoredPosition = new Vector3((int)(-scale * 0.25), -30, 0);
        elizabeth.gameObject.SetActive(true);
        jane.gameObject.SetActive(true);
        elizabeth.currentView = "street";
        jane.currentView = "street";
        elizabeth.emotion = 0;
        jane.emotion = 2;
        //Rose filter on Elizabeth
        effectController.startRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);
        characterBox.text = "Darcy Thoughts"; //Blushing
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("As beautiful as ever...Maybe Bingley will not be the only one proposing tonight...");
        yield return null;
        effectController.stopRoseFilter();
        elizabeth.scale = (int)(1.1 * scale / 3);

        mrBingley.emotion = 6;
        jane.emotion = 1;
        characterBox.text = "Jane Bennet"; //Curious
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Hey guys! How's it going?");
        yield return null;
        jane.emotion = 0;

        mrBingley.emotion = 7;
        characterBox.text = "Mr. Bingley"; //Smiling
        textController.say("It's going really well, thank you for asking...hrrm HRRRMHMHM...");
        yield return null;
        mrBingley.emotion = 6;

        characterBox.text = "Darcy Thoughts"; //Normal
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("That is my queue to lead off Elizabeth.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Awkward
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Miss Elizabeth Bennet, may I speak with you for a second?");
        yield return null;

        elizabeth.emotion = 1;
        characterBox.text = "Elizabeth Bennet"; //Normal
        textController.say("Sure~");
        yield return null;
        elizabeth.emotion = 0;

        characterBox.text = "Darcy Thoughts"; //Smiling
        characterBox.fontStyle = FontStyle.Italic;
        textController.think("Was that a tilde? She seems really excited to talk to me alone.");
        yield return null;

        characterBox.text = "Mr. Darcy"; //Smiling
        characterBox.fontStyle = FontStyle.Normal;
        textController.say("Right this way.");
        yield return null;
        //Bingley and Jane leave
        mrBingley.gameObject.SetActive(false);
        jane.gameObject.SetActive(false);
        ((jane.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((elizabeth.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);
        ((mrBingley.transform) as RectTransform).anchoredPosition = new Vector3(0, -30, 0);

        characterBox.text = "Mr. Darcy"; //Normal
        textController.say("Miss Elizabeth Bennet, not long ago I proposed to you and told you how much I loved you and now...");
        yield return null;
        
        choiceController.offerChoices("I find you really annoying, honestly. How can your emotions seriously have changed so much after one email where you can't even see me?", "Frankly, I don't know what to say.", "my feelings are still unchanged. *Gets down on one knee* Will you marry me?");
        paused = true;
        yield return null;

        if (choice == 1)
        {
            //dialogue for choice 1
            elizabeth.emotion = 5;
            characterBox.text = "Elizabeth Bennet"; //Confused
            textController.say("You don't even know my feelings right now.");
            yield return null;
            elizabeth.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Blushing
            textController.say("Sorry. When I get stressed I starting making random speculations that are not very important.");
            yield return null;

            elizabeth.emotion = 5;
            characterBox.text = "Elizabeth Bennet"; //Confused
            textController.say("What are you stressed about?");
            yield return null;
            elizabeth.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Blushing
            textController.say("What I meant to say was my feelings over the last few months have not shifted at all. *Gets down on one knee* Will you marry me?");
            yield return null;
        }
        else if (choice == 2)
        {
            //dialogue for choice 2
            elizabeth.emotion = 5;
            characterBox.text = "Elizabeth Bennet"; //Confused
            textController.say("About what?");
            yield return null;
            elizabeth.emotion = 4;

            characterBox.text = "Mr. Darcy"; //Blushing
            textController.say("About how my feelings over the last few months have not shifted at all and what to say in a proposal.");
            yield return null;

            characterBox.text = "Mr. Darcy"; //Blushing
            textController.say("Will you marry me?");
            yield return null;
        }
        else
        {
            //dialogue for choice 3
            yield return null;
        }

        elizabeth.emotion = 19;
        characterBox.text = "Elizabeth Bennet"; //BlushingCrying
        textController.say("*Gasp* Wow! Ummm...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //BlushingCrying
        textController.say("I don't know what to say...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //BlushingCrying
        textController.say("After all you've done for my family and me...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //BlushingCrying
        textController.say("...");
        yield return null;

        characterBox.text = "Elizabeth Bennet"; //BlushingCrying
        textController.say("Of course I'll marry you!");
        yield return null;
        elizabeth.emotion = 18;

        //Roll Credits, Here comes the bride music
    }
}
