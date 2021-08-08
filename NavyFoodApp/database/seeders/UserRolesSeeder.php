<?php

namespace Database\Seeders;

use App\Models\UserRoles;
use Illuminate\Database\Seeder;

class UserRolesSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $rolesList = [
            ['id' => 1, 'roleName' => 'Admin',],
            ['id' => 2, 'roleName' => 'Customer',],
            ['id' => 3, 'roleName' => 'Packer',],
            ['id' => 4, 'roleName' => 'Driver',]
        ];
        foreach ($rolesList as $role) {
            UserRoles::create($role);
        }
    }
}
