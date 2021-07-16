<?php

namespace App\Actions\Fortify;

use App\Models\User;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Validator;
use Laravel\Fortify\Contracts\CreatesNewUsers;
use Laravel\Jetstream\Jetstream;

class CreateNewUser implements CreatesNewUsers
{
    use PasswordValidationRules;

    /**
     * Validate and create a newly registered user.
     *
     * @param  array  $input
     * @return \App\Models\User
     */
    public function create(array $input)
    {
        Validator::make($input, [
            'service_number' => ['required', 'string', 'max:12'],
            'rank' => ['required', 'string', 'max:25'],
            'first_name' => ['required', 'string', 'max:20'],
            'last_name' => ['required', 'string', 'max:30'],
            'admin' => ['required', 'boolean'],
            'password' => $this->passwordRules(),
        ])->validate();

        return User::create([
            'service_number' => $input['service_number'],
            'rank' => $input['rank'],
            'first_name' => $input['first_name'],
            'last_name' => $input['last_name'],
            'admin' => $input['admin'],
            'password' => Hash::make($input['password']),
        ]);
    }
}
