using CarBook.Dto.BlogDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AuthorDto
{
    public class ResultAuthorDto
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<ResultGetLast3BlogWithAuthorsDto> Blogs { get; set; }
    }
}
