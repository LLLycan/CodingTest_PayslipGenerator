using CodingExercise.FileHandler.Interface;
using System;
using System.Linq;
using System.Reflection;

namespace CodingExercise.FileHandler.Factory
{
    /// <summary>
    /// Factory & Reflection for create instance based on file type
    /// </summary>
    public class FileProcessorFactory
    {
        /// <summary>
        /// Given a string type of FileProcessorType, create relevant FileProcess instance
        /// </summary>
        /// <param name="type">Type of FileProcessor</param>
        /// <returns>FileProcessor Instance</returns>
        public static IFileProcessor GetFileProcessorType(string type)
        {
            try
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                var currentType = currentAssembly.GetTypes().SingleOrDefault(t => t.Name == type);
                return (IFileProcessor)Activator.CreateInstance(currentType);
            }
            catch (Exception)
            {
                throw new Exception("Cannot find correct file processor type.");
            }
        }
    }
}
