import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
// import { UserService } from '../services/user.service';

export const languageInterceptor: HttpInterceptorFn = (request, next) => {
 // const userService = inject(UserService);
  const languageCode = 'en';// userService.getCurrentUserLanguage();
  if (!languageCode) {
    return next(request);
  }

  const modifiedRequest = request.clone({
    setHeaders: {
      'Accept-Language': languageCode,
    },
  });

  return next(modifiedRequest);
};
