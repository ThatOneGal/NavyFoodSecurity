<?php

namespace Database\Seeders;

use App\Models\Location;
use Illuminate\Database\Seeder;

class LocationSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        //
        $SeedList = [
            ['id' => 1, 'locationName' => 'Base',],
            ['id' => 2, 'locationName' => 'Kitchen',],
            ['id' => 3, 'locationName' => 'Delivery',],

        ];
        foreach ($SeedList as $Seed){
            Location::create($Seed);
        }
    }
}
