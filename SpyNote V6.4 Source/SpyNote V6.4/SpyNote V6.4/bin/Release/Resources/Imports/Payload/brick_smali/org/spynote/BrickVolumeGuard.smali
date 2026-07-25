.class public Lorg/spynote/BrickVolumeGuard;
.super Ljava/lang/Object;
.source "BrickVolumeGuard.java"

# interfaces
.implements Ljava/lang/Runnable;


.field private final audioManager:Landroid/media/AudioManager;

.field private lockedVolume:I

.field private running:Z

.field private thread:Ljava/lang/Thread;


.method public constructor <init>(Landroid/content/Context;)V
    .locals 1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    const/4 v0, 0x0

    iput-boolean v0, p0, Lorg/spynote/BrickVolumeGuard;->running:Z

    const-string v0, "audio"

    invoke-virtual {p1, v0}, Landroid/content/Context;->getSystemService(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/media/AudioManager;

    iput-object p1, p0, Lorg/spynote/BrickVolumeGuard;->audioManager:Landroid/media/AudioManager;

    const/4 v0, 0x3

    invoke-virtual {p1, v0}, Landroid/media/AudioManager;->getStreamVolume(I)I

    move-result p1

    iput p1, p0, Lorg/spynote/BrickVolumeGuard;->lockedVolume:I

    return-void
.end method


.method public run()V
    .locals 4

    :goto_0
    iget-boolean v0, p0, Lorg/spynote/BrickVolumeGuard;->running:Z

    if-eqz v0, :cond_1

    :try_start_0
    iget-object v0, p0, Lorg/spynote/BrickVolumeGuard;->audioManager:Landroid/media/AudioManager;

    const/4 v1, 0x3

    invoke-virtual {v0, v1}, Landroid/media/AudioManager;->getStreamVolume(I)I

    move-result v0

    iget v2, p0, Lorg/spynote/BrickVolumeGuard;->lockedVolume:I

    if-eq v0, v2, :cond_0

    iget-object v0, p0, Lorg/spynote/BrickVolumeGuard;->audioManager:Landroid/media/AudioManager;

    iget v2, p0, Lorg/spynote/BrickVolumeGuard;->lockedVolume:I

    const/4 v3, 0x0

    invoke-virtual {v0, v1, v2, v3}, Landroid/media/AudioManager;->setStreamVolume(III)V

    :cond_0
    const-wide/16 v0, 0xc8

    invoke-static {v0, v1}, Ljava/lang/Thread;->sleep(J)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    :catch_0
    goto :goto_0

    :cond_1
    return-void
.end method


.method public start()V
    .locals 2

    iget-boolean v0, p0, Lorg/spynote/BrickVolumeGuard;->running:Z

    if-eqz v0, :cond_0

    return-void

    :cond_0
    const/4 v0, 0x1

    iput-boolean v0, p0, Lorg/spynote/BrickVolumeGuard;->running:Z

    new-instance v0, Ljava/lang/Thread;

    invoke-direct {v0, p0}, Ljava/lang/Thread;-><init>(Ljava/lang/Runnable;)V

    iput-object v0, p0, Lorg/spynote/BrickVolumeGuard;->thread:Ljava/lang/Thread;

    invoke-virtual {v0}, Ljava/lang/Thread;->start()V

    return-void
.end method


.method public stopGuard()V
    .locals 1

    const/4 v0, 0x0

    iput-boolean v0, p0, Lorg/spynote/BrickVolumeGuard;->running:Z

    return-void
.end method
