// Parsing del testo e dei tag provenienti dal file ink.
// Logica pura, nessuna dipendenza Unity — facilmente testabile.
using System.Collections.Generic;

namespace DeadAir.Narrative
{
    public static class DialogueParser
    {
        #region Costanti Private (Tag Prefixes)
        // Costanti Private (Tag Prefixes)
        private const string TAG_SPEAKER = "speaker:";
        private const string TAG_SFX = "sfx:";
        private const string TAG_AMB = "amb:";
        private const string TAG_UI = "ui:";
        private const string TAG_VOICE = "voice:";
        #endregion

        #region Struct ParsedLine
        // Struct ParsedLine
        public struct ParsedLine
        {
            // Campi pubblici (8 campi):
            public string Text;
            public string Speaker;
            public bool HasSpeaker;

            public string SFX;
            public bool HasSFX;

            public string Ambience;
            public bool HasAmbience;
            public bool IsAmbienceStop;

            public string UICommand;
            public bool HasUICommand;

            public string VoiceId;
            public bool HasVoice;
        }
        #endregion

        #region Methods
        // Metodo ParseTags
        public static ParsedLine ParseTags(List<string> tags, string lineText)
        {
            // 1. Inizializza result con tutti i campi a default
            var result = new ParsedLine
            {
                Text = lineText?.Trim() ?? string.Empty,
                Speaker = null,
                HasSpeaker = false,
                SFX = null,
                HasSFX = false,
                Ambience = null,
                HasAmbience = false,
                IsAmbienceStop = false,
                UICommand = null,
                HasUICommand = false,
                VoiceId = null,
                HasVoice = false
            };

            // 2. Se tags è null/vuota, ritorna result
            if (tags == null || tags.Count == 0)
                return result;

            // 3. Loop foreach su tags
            //    - Trim e ToLowerInvariant
            //    - Controlla StartsWith per ogni prefisso
            //    - Usa ExtractValue per estrarre il valore
            //    - Setta i campi corrispondenti
            // Single pass attraverso i tag
            foreach (string tag in tags)
            {
                string trimmedTag = tag.Trim().ToLowerInvariant();

                // Speaker tag
                if (trimmedTag.StartsWith(TAG_SPEAKER))
                {
                    result.Speaker = ExtractValue(trimmedTag, TAG_SPEAKER);
                    result.HasSpeaker = !string.IsNullOrEmpty(result.Speaker);
                }
                // Voice tag
                else if (trimmedTag.StartsWith(TAG_VOICE))
                {
                    result.VoiceId = ExtractValue(trimmedTag, TAG_VOICE);
                    result.HasVoice = !string.IsNullOrEmpty(result.VoiceId);
                }
                // SFX tag
                else if (trimmedTag.StartsWith(TAG_SFX))
                {
                    result.SFX = ExtractValue(trimmedTag, TAG_SFX);
                    result.HasSFX = !string.IsNullOrEmpty(result.SFX);
                }
                // Ambience tag
                else if (trimmedTag.StartsWith(TAG_AMB))
                {
                    string ambienceValue = ExtractValue(trimmedTag, TAG_AMB);

                    if (ambienceValue == "stop")
                    {
                        result.IsAmbienceStop = true;
                        result.HasAmbience = true;
                    }
                    else
                    {
                        result.Ambience = ambienceValue;
                        result.HasAmbience = !string.IsNullOrEmpty(result.Ambience);
                    }
                }
                // UI tag
                else if (trimmedTag.StartsWith(TAG_UI))
                {
                    result.UICommand = ExtractValue(trimmedTag, TAG_UI);
                    result.HasUICommand = !string.IsNullOrEmpty(result.UICommand);
                }
            }
            // 4. Ritorna result
            return result;
        }
        // Helper Methods
        private static string ExtractValue(string tag, string prefix)
        {
            if (tag.Length <= prefix.Length)
                return string.Empty;

            return tag.Substring(prefix.Length).Trim();
        }
        #endregion
    }
}


