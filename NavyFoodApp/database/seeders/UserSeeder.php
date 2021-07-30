<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;
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
        //
        $UserList = [
            [
                'firstname' => 'AdminFirst',
                'lastname' => 'AdminLast',
                'rank' => 'AdminRank',
                'serialnumber' => 'AdminSerial',
                'email' => 'Admin@Admin.com',
                'password' => Hash::make('AdminPassword'),
            ],
            [
                'firstname' => 'Kyana',
                'lastname' => 'Bowers',
                'rank' => 'Soldier',
                'serialnumber' => '123456',
                'email' => 'KBowers@Soldier.com',
                'password' => Hash::make('Password'),
            ],
            [
                'firstname' => 'William',
                'lastname' => 'Te',
                'rank' => 'Soldier',
                'serialnumber' => '654321',
                'email' => 'WTe@Soldier.com',
                'password' => Hash::make('Password'),
            ],


        ];
        foreach ($UserList as $User){
            User::create($User);
        }
    }
}
