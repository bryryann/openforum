package com.bryryann.openforum.api.controller;

import com.bryryann.openforum.api.dto.user.LoginRequest;
import com.bryryann.openforum.api.dto.user.LoginResponse;
import com.bryryann.openforum.api.dto.user.RegisterRequest;
import com.bryryann.openforum.api.model.User;
import com.bryryann.openforum.api.repository.UserRepository;
import com.bryryann.openforum.api.security.UserRole;
import com.bryryann.openforum.api.service.JwtTokenService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/auth")
public class AuthController {

    private final UserRepository repository;
    private final AuthenticationManager authenticationManager;
    private final JwtTokenService jwtTokenService;

    @Autowired
    public AuthController(
            UserRepository repository,
            AuthenticationManager authenticationManager,
            JwtTokenService jwtTokenService
    ) {
        this.repository = repository;
        this.authenticationManager = authenticationManager;
        this.jwtTokenService = jwtTokenService;
    }

    /**
     * Endpoint for handling user login.
     * @param request  Contains username and password.
     * @return         If successful, send a JWT Token as response. Otherwise, Forbidden.
     */
    @PostMapping("/login")
    public ResponseEntity<LoginResponse> login(@RequestBody LoginRequest request) {
        var userToken =
                new UsernamePasswordAuthenticationToken(request.username(), request.password());
        var auth = authenticationManager.authenticate(userToken);

        var token = jwtTokenService.generateToken((User) auth.getPrincipal());

        return ResponseEntity.ok(new LoginResponse(token));
    }

    /**
     * Endpoint for registering a new user to the database.
     * @param request  Contains username and password.
     * @return         Bad Request in case user is already registered, otherwise returns ok.
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
