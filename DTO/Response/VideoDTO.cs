using Domain.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class VideoDTO
    {
        public long LessonId { get; set; }
        public string Format { get; set; }
        public string Url { get; set; }

        public VideoDTO() { }

        public VideoDTO(Video video)
        {
            if (video == null)
                return;
            LessonId = video.Lesson.ID;
            Format = video.Format;
            Url = video.Url;
        }
    }
}
