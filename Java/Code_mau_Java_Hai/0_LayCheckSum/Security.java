package poly.service;

import java.security.SignatureException;

import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;

import org.apache.commons.codec.binary.Base64;


public class Security {
	private static final String HMAC_SHA1_ALGORITHM = "HmacSHA1";

	public static String hmac(String data, String key) throws java.security.SignatureException {//key do viettel cung cap
	 String result;
	 try {
	 SecretKeySpec signingKey = new SecretKeySpec(key.getBytes(), HMAC_SHA1_ALGORITHM);
	 Mac mac = Mac.getInstance(HMAC_SHA1_ALGORITHM);
	 mac.init(signingKey);
	 byte[] rawHmac = mac.doFinal(data.getBytes());
	 result = new String(Base64.encodeBase64(rawHmac));
	 } catch (Exception e) {
	 throw new SignatureException("Failed to generate HMAC : " + e.getMessage());
	 }
	 return result;
	 }
	
}
