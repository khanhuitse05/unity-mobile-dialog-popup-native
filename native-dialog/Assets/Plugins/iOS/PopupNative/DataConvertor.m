//  Created by Nikunj Rola - TheAppGuruz

#import "DataConvertor.h"

@implementation DataConvertor

+(NSString *) charToNSString:(char *)value {
    if (value != NULL) {
        return [NSString stringWithUTF8String: value];
    } else {
        return [NSString stringWithUTF8String: ""];
    }
}

+(const char *)NSIntToChar:(NSInteger)value {
    NSString *tmp = [NSString stringWithFormat:@"%ld", (long)value];
    return [tmp UTF8String];
}

+ (const char *)NSStringToChar:(NSString *)value {
    return [value UTF8String];
}

@end


