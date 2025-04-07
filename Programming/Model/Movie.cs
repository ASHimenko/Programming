using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model
{
    public class Movie
    {
        private int _durationMinutes;
        private int _releaseYear;
        private double _reting;

        public string Title { get; set; }
        public string Genre { get; set; }

        public int DurationMinutes
        {
            get { return _durationMinutes; }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(DurationMinutes));
                _durationMinutes = value;
            }
        }

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set
            {
                Validator.AssertValueInRange(value, 1900, DateTime.Now.Year, nameof(ReleaseYear));
                _releaseYear = value;
            }
        }

        public double Rating
        {
            get { return _reting; }
            set
            {
                Validator.AssertValueInRange(value, 0, 10, nameof(Rating));
                _reting = value;
            }
        }

        public Movie() { }

        public Movie(string title, int durationMinutes, int releaseYear, string genre, double rating)
        {
            Title = title;
            DurationMinutes = durationMinutes;
            ReleaseYear = releaseYear;
            Genre = genre;
            Rating = rating;
        }
    }
}
