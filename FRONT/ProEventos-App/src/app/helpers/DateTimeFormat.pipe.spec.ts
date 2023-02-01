/* tslint:disable:no-unused-variable */

import { TestBed, async } from '@angular/core/testing';
import { DateTimeFormatPipe } from './DateTimeFormat.pipe';

describe('Pipe: DateTimeFormat', () => {
  it('create an instance', () => {
    const pipe = new DateTimeFormatPipe('01/01/2022');
    expect(pipe).toBeTruthy();
  });
});
