<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $users = [
            [
                'service_number' => '2021Admin',
                'rank' => 'Admiral',
                'first_name' => 'Horatio',
                'last_name' => 'Nelson',
                'admin' => 1,
                'password' => Hash::make('Password1'),
            ],

            [
                'service_number' => 'AO279523',
                'rank' => 'Major',
                'first_name' => 'Fred',
                'last_name' => 'Disaster',
                'admin' => 0,
                'password' => Hash::make('Password2'),
            ],

            [
                'service_number' => 'BB47326',
                'rank' => 'Corporal',
                'first_name' => 'George',
                'last_name' => 'Punishment',
                'admin' => 0,
                'password' => Hash::make('Password3'),
            ],

            [
                'service_number' => 'A590882',
                'rank' => 'Private',
                'first_name' => 'Jack',
                'last_name' => 'Partz',
                'admin' => 0,
                'password' => Hash::make('Password4'),
            ]
        ];

        foreach ($users as $user) {
            User::create($user);
        }
    }
}
