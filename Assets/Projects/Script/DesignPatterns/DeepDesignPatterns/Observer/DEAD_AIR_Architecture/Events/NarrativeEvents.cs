// hub statico per il pattern Observer.
// Un hub eventi statico permette a qualsiasi script di pubblicare/sottoscrivere senza riferimenti diretti.
// Comodo ma globale. Accettabile per un sistema narrativo centrale.
using System;
using System.Collections.Generic;
using Ink.Runtime;

namespace DeadAir.Events
{
    public static class NarrativeEvents
    {
        #region Events
        // Dialogue Events
        public static event Action<string> OnDialogueLine;
        public static event Action<string, string> OnSpeakerLine; // (speaker, text)
        // public static event Action<List<Choice>> OnChoicesPresented; // (choices)
        public static event Action<int> OnChoiceSelected; // (choiceIndex)

        // Audio Events
        public static event Action<string> OnSFXRequested; // (sfxId)
        public static event Action<string> OnAmbienceStart; // (ambienceId)
        public static event Action OnAmbienceStop;
        public static event Action<string> OnVoiceRequested; // (voiceId)
        public static event Action OnVoiceStop;

        // UI Events
        public static event Action<string> OnUICommand; //  (command)

        // Story Flow Events
        public static event Action OnStoryEnd;
        public static event Action OnContinueRequested;

        // Voice Playback Events
        public static event Action<float> OnVoiceStarted; // (duration)
        public static event Action OnVoiceFinished;
        #endregion

        #region Metodi Wrapper
        // Metodi Wrapper (Invoke)
        public static void DialogueLine(string text)
        {
            OnDialogueLine?.Invoke(text);
        }
        public static void SpeakerLine(string speaker, string text)
        {
            OnSpeakerLine?.Invoke(speaker, text);
        }
        // public static void ChocesPresented(List<Choice> choices)
        // {
        //     OnChoicesPresented?.Invoke(choices);
        // }
        public static void ChoiceSelected(int choiceIndex)
        {
            OnChoiceSelected?.Invoke(choiceIndex);
        }
        public static void SFXRequested(string sfxId)
        {
            OnSFXRequested?.Invoke(sfxId);
        }
        public static void AmbienceStart(string ambienceId)
        {
            OnAmbienceStart?.Invoke(ambienceId);
        }
        public static void AmbienceStop()
        {
            OnAmbienceStop?.Invoke();
        }
        public static void VoiceRequested(string voiceId)
        {
            OnVoiceRequested?.Invoke(voiceId);
        }
        public static void VoiceStop()
        {
            OnVoiceStop?.Invoke();
        }
        public static void UICommand(string command)
        {
            OnUICommand?.Invoke(command);
        }
        public static void StoryEnd()
        {
            OnStoryEnd?.Invoke();
        }
        public static void ContinueRequested()
        {
            OnContinueRequested?.Invoke();
        }
        public static void VoiceStarted(float duration)
        {
            OnVoiceStarted?.Invoke(duration);
        }
        public static void VoiceFinished()
        {
            OnVoiceFinished?.Invoke();
        }
        #endregion

        #region CleanUP
        // Metodo Cleanup
        public static void ClearAllListeners()
        {
            OnDialogueLine = null;
            OnSpeakerLine = null;
            // OnChoicesPresented = null;
            OnChoiceSelected = null;

            // Audio Events
            OnSFXRequested = null;
            OnAmbienceStart = null;
            OnAmbienceStop = null;
            OnVoiceRequested = null;
            OnVoiceStop = null;

            // UI Events
            OnUICommand = null;

            // Story Flow Events
            OnStoryEnd = null;
            OnContinueRequested = null;

            // Voice Playback Events
            OnVoiceStarted = null;
            OnVoiceFinished = null;
        }
        #endregion
    }
}


