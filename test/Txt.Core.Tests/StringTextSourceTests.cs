﻿using System;
using System.Linq;
using Xunit;

namespace Txt.Core
{
    public class StringTextSourceTests
    {
        private const string Sentence = "The quick brown fox jumps over the lazy dog";

        [Fact]
        public void WhenNewWithEmptyString_ExpectObjectIsCreated()
        {
            // When creating a new StringTextSource with an empty string
            // Then no exception is thrown
            var sut = new StringTextSource("");
        }

        [Fact]
        public void WhenNewWithNullArgument_ExpectArgumentNullException()
        {
            // When creating a new StringTextSource with a null argument
            // Then an ArgumentNullException is thrown
            StringTextSource sut;
            Assert.Throws<ArgumentNullException>(() => sut = new StringTextSource((string)null));
        }

        [Fact]
        public void WhenRead_ExpectCharacterIsReturnedAndConsumed()
        {
            // Given that there is text to be read
            // When Read is called
            // Then the next available character is returned
            //  And the character is consumed
            using (var sut = new StringTextSource("abc"))
            {
                var read = (char)sut.Read();
                Assert.Equal('a', read);

                // Verify behavior by peeking at the next character
                var peek = (char)sut.Peek();
                Assert.NotEqual('a', peek);
            }
        }

        [Fact]
        public void WhenReadingEndOfSource_ExpectMinusOne()
        {
            // Given that the text source has been initialized with an string
            // When Read is called
            // Then -1 is returned
            var sut = new StringTextSource("");
            var read = sut.Read();
            Assert.Equal(-1, read);
        }

        [Fact]
        public void WhenReadWithBuffer_ExpectTextIsReturnedAndConsumed()
        {
            // Given that there is text to be read
            // When Read is called
            // Then the buffer contains the text
            //  And the text is consumed
            using (var sut = new StringTextSource(Sentence))
            {
                var buffer = new char[Sentence.Length];
                var len = sut.Read(buffer, 0, buffer.Length);
                Assert.Equal(buffer.Length, len);
                Assert.Equal(Sentence.ToCharArray(), buffer);

                // Verify behavior by peeking at the next character
                Assert.Equal(-1, sut.Peek());
            }
        }

        [Fact]
        public void WhenReadWithBufferBiggerThanTextSource_ExpectResultLessThanBufferSize()
        {
            // Given that there is text to be read
            // When Read is called with a buffer
            //  And the buffer length is larger than the length of the text
            // Then the buffer contains the text
            //  And the returned length is less than the length of the buffer
            //  And the text is consumed
            using (var sut = new StringTextSource(Sentence))
            {
                var buffer = new char[Sentence.Length*2];
                var len = sut.Read(buffer, 0, buffer.Length);
                Assert.Equal(Sentence.Length, len);
                Assert.Equal(Sentence.ToCharArray(), buffer.Take(len));

                // Verify behavior by peeking at the next character
                Assert.Equal(-1, sut.Peek());
            }
        }

        [Fact]
        public void WhenReadWithCountBeyondBufferLength_ExpectArgumentOutOfRangeException()
        {
            // Given that the text source has been initialized with a non-empty string
            // When Read is called with a count that exceeds the buffer length
            // Then an ArgumentOutOfRangeException is thrown
            var sut = new StringTextSource(Sentence);
            var buffer = new char[Sentence.Length];
            int read;
            Assert.Throws<ArgumentOutOfRangeException>(() => read = sut.Read(buffer, 0, buffer.Length + 1));
        }

        [Fact]
        public void WhenReadWithEmptyBuffer_ExpectArgumentNullException()
        {
            // Given that the text source has been initialized with a non-empty string
            // When Read is called with a buffer that is a null reference
            // Then an ArgumentNullException is thrown
            var sut = new StringTextSource(Sentence);
            int read;
            Assert.Throws<ArgumentNullException>(() => read = sut.Read(null, 0, Sentence.Length));
        }

        [Fact]
        public void WhenReadWithNegativeCount_ExpectArgumentOutOfRangeException()
        {
            // Given that the text source has been initialized with a non-empty string
            // When Read is called with a negative count
            // Then an ArgumentOutOfRangeException is thrown
            var sut = new StringTextSource(Sentence);
            var buffer = new char[Sentence.Length];
            int read;
            Assert.Throws<ArgumentOutOfRangeException>(() => read = sut.Read(buffer, 0, -1));
        }

        [Fact]
        public void WhenReadWithNegativeOffset_ExpectArgumentOutOfRangeException()
        {
            // Given that the text source has been initialized with a non-empty string
            // When Read is called with a negative offset
            // Then an ArgumentOutOfRangeException is thrown
            var sut = new StringTextSource(Sentence);
            var buffer = new char[Sentence.Length];
            int read;
            Assert.Throws<ArgumentOutOfRangeException>(() => read = sut.Read(buffer, -1, buffer.Length));
        }

        [Fact]
        public void WhenReadWithOffsetAndCountCombinationBeyondBufferLength_ExpectArgumentOutOfRangeException()
        {
            // Given that the text source has been initialized with a non-empty string
            // When Read is called with an offset and count whose sum exceeds the buffer length
            // Then an ArgumentOutOfRangeException is thrown
            var sut = new StringTextSource(Sentence);
            var buffer = new char[Sentence.Length];
            int read;
            Assert.Throws<ArgumentOutOfRangeException>(() => read = sut.Read(buffer, 1, buffer.Length));
        }

        [Fact]
        public void WhenReadWithOffsetBeyondBufferLength_ExpectArgumentOutOfRangeException()
        {
            // Given that the text source has been initialized with a non-empty string
            // When Read is called with an offset that is beyond the buffer length
            // Then an ArgumentOutOfRangeException is thrown
            using (var sut = new StringTextSource(Sentence))
            {
                var buffer = new char[Sentence.Length];
                int read;
                Assert.Throws<ArgumentOutOfRangeException>(() => read = sut.Read(buffer, buffer.Length + 1, 0));
            }
        }
    }
}
