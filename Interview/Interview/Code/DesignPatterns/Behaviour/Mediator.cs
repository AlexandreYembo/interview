using System;
using System.Collections.Generic;
using Interview.Factory;
using Interview.Helpers;

namespace Interview.Code.DesignPatterns.Behaviour
{
    public class Mediator : ICode
    {
        public void Run()
        {
            //Create Chatroom
            Chatroom chatroom = new Chatroom();

            //Create and Register Participants
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");
            Participant Alexandre = new NonBeatle("Alexandre");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);
            chatroom.Register(Alexandre);

            //Chatting participants
            Alexandre.Send("Yoko", "Hi Yoko!");
            Yoko.Send("Alexandre", "Hi Alexandre!");
            Alexandre.Send("Yoko", "Let's talk to John!");
            Alexandre.Send("John", "Hi John!, can you say hi to Paul?");
            John.Send("Paul", "Hi Paul, Alexandre asked about you!");
            Paul.Send("Alexandre", "Hi Alexandre how are you?");
            Alexandre.Send("Paul", "Hi Paul, do you know where is Ringo? Yoko needs his help");
            Paul.Send("Ringo", "Hi Ringo, Yoko needs a help!");
            Ringo.Send("Yoko", "Hi Yoko, I am ringo, what do you need?");

            // Wait for user
            Console.ReadKey();
        }
    }

    //Step 1 - Define the abstract class of the Mediator
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);

        public abstract void Send(string from, string to, string message);
    }

    //Step 2 - Implement the abstract class of the Mediator
    public class Chatroom : AbstractChatroom
    {
        private IDictionary<string, Participant> participants = new Dictionary<string, Participant>();
        public override void Register(Participant participant)
        {
            if (!participants.ContainsKey(participant.Name))
            {
                participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            var participant = participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    //Step 3 - Define the abstract Participant class
    public abstract class Participant
    {
        public Participant(string name)
        {
            Name = name;
        }

        public Chatroom Chatroom { get; set; }
        public string Name { get; set; }

        // Sends message to given participant
        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        // Receives message from given participant
        public virtual void Receive(string from, string message)
        {
            Print.PrintRow($"{from} to {Name}: '{message}'");
        }
    }

    //Step 4 - Implement the concrete class from Participant
    public class Beatle : Participant
    {
        public Beatle(string name) : base(name)
        { }

        public override void Receive(string from, string message)
        {
            Print.PrintRow("To a Beatle: ");
            base.Receive(from, message);
        }
    }
    public class NonBeatle : Participant
    {
        public NonBeatle(string name) : base(name)
        { }

        public override void Receive(string from, string message)
        {
            Print.PrintRow("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}