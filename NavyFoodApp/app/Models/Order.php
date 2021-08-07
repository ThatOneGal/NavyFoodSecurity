<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Order extends Model
{
    use HasFactory;


protected $fillable = [
    'id',
    'CustomerId',
    'LocationId',
    'StatusId',
    'OrderDate',
    'OrderShipped',
    'OrderPacked',
    'PackerId',
    'DriverId',
    'Content',
    'PackageQty',
    'NotesStorage',
    'NotesPreparation',

];

}
