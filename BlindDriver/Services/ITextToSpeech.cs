namespace BlindDriver
{
    public interface ITextToSpeech
    {
        void Speak(string text, bool? queueing=true);
    }
}
