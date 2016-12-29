using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXTPortal.Common;
using System.IO;
using System.Drawing;
using System.Configuration;
using log4net;

namespace JXTMoveImageToFTP
{
    public interface IProcessor
    {
        string Type { get; }
        int Priority { get; }
        void Begin(int? batchSize, bool isDebug);
    }

    public abstract class Processor<T> : IProcessor
    {
        protected ILog Logger { get; private set; }

        public Processor()
        {
            Logger = LogManager.GetLogger(typeof(IProcessor));

        }
        public abstract string Type { get; }

        public abstract int Priority { get; }

        public abstract string Folder { get; }

        public abstract IEnumerable<T> GetEntitiesToUpdate(int? batchSize);

        public abstract byte[] GetBinaryData(T entity);
        public abstract int GetId(T entity);
        public abstract void UpdateEntity(T entity, string filename);
        public abstract bool PerformFileSave(T entity, string path, out string filename); 

        public void Begin(int? batchSize, bool isDebug)
        {
            Logger.InfoFormat("Start moving {0} Binary Data to FTP", Type);

            string path = string.Format(@"{0}\{1}", ConfigurationManager.AppSettings["RootFolder"], Folder);

            // Check if directory exists
            if (!Directory.Exists(path))
            {
                Logger.InfoFormat("Directory doesn't exist, creating directory {0}", path);

                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    return;
                }
            }

            //Only migrate sites that have a logo, but not one that has already been migrated
            IEnumerable<T> entities = GetEntitiesToUpdate(batchSize);

            Logger.DebugFormat("Found {0} {1} to migrate", entities.Count(), Type);

            foreach (T entity in entities)
            {
                string filename = null;
                if (PerformFileSave(entity, path, out filename) && !isDebug)
                {
                    UpdateEntity(entity, filename);
                }
            }
        }
    }

    public abstract class ImageProcessor<T> : Processor<T>
    {
        public override bool PerformFileSave(T entity, string path, out string filename)
        {
            int entityId = GetId(entity);
            Logger.InfoFormat("Beginning Saving binary data for {0} with id {1}", Type, entityId);

            filename = null;

            byte[] buffer = GetBinaryData(entity);
            if (buffer == null || buffer.Length <= 0)
            {
                Logger.Warn("Nothing to save");
                return false;
            }

            try
            {
                using (var ms = new MemoryStream(buffer))
                {
                    var image = Image.FromStream(ms);
                    filename = string.Format("{0}_{1}.{2}", Type, entityId, image.GetExtension());
                    string newPath = string.Format(@"{0}\{1}", path, filename);

                    // Upload to FTP
                    Logger.InfoFormat("Saving image to {0}", newPath);
                    image.Save(newPath);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                filename = null;
                return false;
            }
            Logger.InfoFormat("successfully Saved image {0}", filename);
            return true;
        }
    }
}