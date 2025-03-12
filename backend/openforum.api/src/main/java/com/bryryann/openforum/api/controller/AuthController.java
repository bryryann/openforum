package com.bryryann.openforum.api.controller;

import com.bryryann.openforum.api.dto.user.LoginRequest;
import com.bryryann.openforum.api.dto.user.RegisterRequest;
import com.bryryann.openforum.api.model.User;
import com.bryryann.openforum.api.repository.UserRepository;
import com.bryryann.openforum.api.security.UserRole;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/auth")
public class AuthController {

    private final UserRepository repository;

    @Autowired
    public AuthController(UserRepository repository) {
        this.repository = repository;
    }

    @PostMapping("/login")
    public ResponseEntity login(@RequestBody LoginRequest request) {
        // not implemented yet
        return ResponseEntity.ok().build();
    }

    /**
     * Endpoint for registering a new user to the database.
     * @param request  contains username and password.
     * @return         bad request in case user is already registered, otherwise returns ok.
     */
    @PostMapping("/register")
    public ResponseEntity register(@RequestBody RegisterRequest request) {
        if (repository.findByUsername(request.username()) != null)
            return ResponseEntity.badRequest().build();

        String passwordHash = new BCryptPasswordEncoder().encode(request.password());
        User newUser = new User(request.username(), passwordHash, UserRole.USER);
        repository.save(newUser);

        return ResponseEntity.ok().build();
    }
}
