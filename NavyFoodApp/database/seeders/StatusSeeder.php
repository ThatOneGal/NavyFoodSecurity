<?php

namespace Database\Seeders;

use App\Models\Status;
use Illuminate\Database\Seeder;

class StatusSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        //
        $StatusList = [
            ['id' => 1, 'statusName' => 'Created',],
            ['id' => 2, 'statusName' => 'Packing',],
            ['id' => 3, 'statusName' => 'Packed',],
            ['id' => 4, 'statusName' => 'Awaiting Delivery',],
            ['id' => 5, 'statusName' => 'In transit',],
            ['id' => 6, 'statusName' => 'Delivered',]
        ];
        foreach ($StatusList as $Stat){
            Status::create($Stat);
        }
    }
}
