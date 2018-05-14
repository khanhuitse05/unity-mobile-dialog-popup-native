//  Created by Nikunj Rola - TheAppGuruz

#import <Foundation/Foundation.h>

@interface DataConvertor : NSObject

+ (NSString*) charToNSString: (char*)value;
+ (const char *) NSIntToChar: (NSInteger) value;
+ (const char *) NSStringToChar: (NSString *) value;

@end

