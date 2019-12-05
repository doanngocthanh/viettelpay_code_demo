
    static string getCheck_sum(string value)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(hash_key);
            byte[] messageBytes = encoding.GetBytes(value);
            using (var hmacsha1 = new HMACSHA1(keyByte))
            {
                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
                check_sum = Convert.ToBase64String(hashmessage).Replace("=", "%3d").Replace(" ", "+");
            }
            return check_sum;
        }