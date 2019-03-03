namespace Jock.HB.BL.Utilities
{
    using System;
    using System.Windows;

    /// <summary>
    /// Обёртка над MessageBox.
    /// </summary>
    public static class MessageBoxer
    {
        /// <summary>
        /// Ошибка.
        /// </summary>
        /// <param name="message">Текст ошибки.</param>
        /// <param name="title">Заголовок окна.</param>
        public static void Error(string message, string title = "")
        {
            Show(message, title, MessageBoxImage.Error);
        }

        /// <summary>
        /// Информирование.
        /// </summary>
        /// <param name="message">Текст информации.</param>
        /// <param name="title">Заголовок окна.</param>
        public static void Info(string message, string title = "")
        {
            Show(message, title, MessageBoxImage.Information);
        }

        /// <summary>
        /// Предупреждение.
        /// </summary>
        /// <param name="message">Текст предупреждения.</param>
        /// <param name="title">Заголовок окна.</param>
        public static void Warning(string message, string title = "")
        {
            Show(message, title, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Открыть MessageBox.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="title">Заголовок окна.</param>
        /// <param name="image">Иконка внутри MessageBox.</param>
        private static void Show(string message, string title, MessageBoxImage image)
        {
            var windowTitle = "Информация.";
            MessageBox.Show(message, windowTitle, MessageBoxButton.OK, image);
        }

        /// <summary>
        /// Вопрос Да/Нет.
        /// </summary>
        /// <param name="title">Заголовок.</param>
        /// <param name="text">Текст.</param>
        /// <returns>True - пользователь ответил Да.</returns>
        public static bool YesNoQuestion(string title, string text)
        {
            var result = MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
