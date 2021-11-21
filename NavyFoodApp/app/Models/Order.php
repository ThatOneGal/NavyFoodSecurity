<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Order extends Model
{
    use HasFactory;
    use SoftDeletes;


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
