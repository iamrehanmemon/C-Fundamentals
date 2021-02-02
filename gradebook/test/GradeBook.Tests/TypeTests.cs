using System;
using Xunit;

namespace GradeBook.Tests
{   
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {   
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            
            // log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3,count);
            Assert.Equal("Hello!",result);
        }

         string IncrementCount(string message)
        {
            count ++;
            return message.ToLower();
        }
         string ReturnMessage(string message)
        {
            count ++;
            return message;
        }



        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42,x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }


        // Pass by Reference
        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1,"New Name");

            Assert.Equal("New Name",book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {   
            book =  new Book(name);
        }

        // Default is always pass by Value
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1,"New Name");

            Assert.Equal("Book 1",book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {   
            book =  new Book(name);
            // book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1,"New Name");

            Assert.Equal("New Name",book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }


        [Fact]
        //String are reference type and are immunaable
        public void StringBehaveLikeValueTypes()
        {
            String name= "Rehan";
            var upper = MakeUpperCase(name);   

            Assert.Equal("Rehan",name);
            Assert.Equal("REHAN",upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1,book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }

        Book GetBook(string name)
        { 
            return new Book(name);
        }
    }
}