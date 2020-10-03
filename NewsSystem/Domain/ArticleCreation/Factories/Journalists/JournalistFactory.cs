namespace NewsSystem.Domain.ArticleCreation.Factories.Journalists
{
    using Models.Journalists;
    using NewsSystem.Domain.ArticleCreation.Exceptions;

    internal class JournalistFactory : IJournalistFactory
    {
        private string userId = default!;
        private string nickName = default!; 

        private Address address = default!;
        private PhoneNumber phoneNumber = default!;  

        public IJournalistFactory WithUserId(string userId)
        {
            this.userId = userId;
            return this;
        }

        public IJournalistFactory WithNickName(string nickName)
        {
            this.nickName = nickName;
            return this;
        }

        public IJournalistFactory WithAddress(Address address)
        {
            this.address = address; 
            return this;
        }

        public IJournalistFactory WithAddress(string address)
             => this.WithAddress(new Address(address));

        public IJournalistFactory WithPhoneNumber(PhoneNumber phoneNumber)
        {
            this.phoneNumber = phoneNumber; 
            return this;
        }

        public IJournalistFactory WithPhoneNumber(string phoneNumber)
            => this.WithPhoneNumber(new PhoneNumber(phoneNumber));

        public Journalist Build() => new Journalist(this.nickName, this.userId, this.address, this.phoneNumber);

        public Journalist Build(string nickName, string userId, string address, string phoneNumber)
            => this
                .WithNickName(nickName)
                .WithUserId(userId)
                .WithAddress(address)
                .WithPhoneNumber(phoneNumber)
                .Build();

    }
}
