package com.bryryann.openforum.api.service;

import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;
import com.auth0.jwt.exceptions.JWTCreationException;
import com.auth0.jwt.exceptions.JWTVerificationException;
import com.bryryann.openforum.api.model.User;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneOffset;

@Service
public class JwtTokenService {

    @Value("${api.security.token.secret}")
    private String secret;

    /**
     * Generates a new JWT token based on the given user credentials.
     * @param user               POJO containing User table data.
     * @return                   A String of the generated JWT Token.
     * @throws RuntimeException  An error occurs during JWT token generation.
     */
    public String generateToken(User user) throws RuntimeException {
        try {
            Algorithm algorithm = Algorithm.HMAC256(secret);
            return JWT.create()
                    .withIssuer("openforum.api")
                    .withSubject(user.getUsername())
                    .withExpiresAt(genExpirationDate())
                    .sign(algorithm);
        } catch (JWTCreationException exception) {
            throw new RuntimeException("Error during JWT Token generation", exception);
        }
    }

    /**
     * Check whether a given token is indeed valid.
     * @param token  token string for validation.
     * @return       If validation is successful, return a String of the username contained in it,
     * otherwise, return an empty string.
     */
    public String validateToken(String token) {
        try {
            Algorithm algorithm = Algorithm.HMAC256(secret);
            return JWT.require(algorithm)
                    .withIssuer("openforum.api")
                    .build()
                    .verify(token)
                    .getSubject();
        } catch (JWTVerificationException exception) {
            return "";
        }
    }

    /**
     * Helper method for creating the expiration date of the JWT token.
     * @return  An instant that represents 4 hours after the moment when the method is called.
     */
    public Instant genExpirationDate() {
        return LocalDateTime.now().plusHours(4).toInstant(ZoneOffset.UTC);
    }
}
